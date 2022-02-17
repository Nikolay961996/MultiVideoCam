using MultiVideoCam.Data.Modals;
using MultiVideoCam.Models;

namespace MultiVideoCam.Services.Interfaces
{
    public interface ICamerasService
    {
        Task<ICollection<CameraViewModal>> GetAllCameras(CancellationToken cancellationToken);

        Task AddNewCamera(AddNewCamDto dto, CancellationToken cancellationToken);

        Task RemoveCamera(DeleteCamDto dto, CancellationToken cancellationToken);
    }
}
