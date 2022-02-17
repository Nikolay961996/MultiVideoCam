using AutoMapper;
using MultiVideoCam.Data.Entities;
using MultiVideoCam.Mappings;

namespace MultiVideoCam.Data.Modals
{
    public class CameraViewModal : BaseViewModal<long>, IMapWith<Camera>
    {
        public string Link { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Camera, CameraViewModal>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Link, opt => opt.MapFrom(src => src.Link))
                ;
        }
    }
}
