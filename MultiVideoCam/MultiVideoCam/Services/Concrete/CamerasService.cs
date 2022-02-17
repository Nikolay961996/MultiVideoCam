using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiVideoCam.Data;
using MultiVideoCam.Data.Entities;
using MultiVideoCam.Data.Modals;
using MultiVideoCam.Models;
using MultiVideoCam.Services.Interfaces;

namespace MultiVideoCam.Services.Concrete
{
    public class CamerasService : ICamerasService
    {
        private readonly CamerasDbContext _dataContext;
        private readonly IMapper _mapper;

        public CamerasService(
            CamerasDbContext dataContext,
            IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ICollection<CameraViewModal>> GetAllCameras(CancellationToken cancellationToken)
        {
            var cameras = await _dataContext.Cameras.ToListAsync(cancellationToken);

            var m = _mapper.Map<ICollection<CameraViewModal>>(cameras);

            return m;
        }

        public async Task AddNewCamera(AddNewCamDto dto, CancellationToken cancellationToken)
        {
            await CheckUrl(dto.Link);

            await _dataContext.Cameras.AddAsync(new Camera()
            {
                CreatedDate = DateTime.UtcNow,
                Link = dto.Link
            }, cancellationToken);

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        public async Task RemoveCamera(DeleteCamDto dto, CancellationToken cancellationToken)
        {
            var camera = await _dataContext.Cameras.FindAsync(dto.Id);
            if (camera == null)
                throw new KeyNotFoundException("Not found camera Id");

            camera.DeletedDate = DateTime.UtcNow;

            await _dataContext.SaveChangesAsync(cancellationToken);
        }

        private async Task CheckUrl(string url)
        {
            if (url.EndsWith(".m3u8") == false)
                throw new BadHttpRequestException("You must write only *.m3u8");
            var client = new HttpClient();
            _ = await client.GetAsync(new Uri(url));
        }
    }
}
