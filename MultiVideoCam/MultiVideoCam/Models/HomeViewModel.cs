using MultiVideoCam.Data.Modals;

namespace MultiVideoCam.Models
{
    public class HomeViewModel
    {
        public ICollection<CameraViewModal> Cameras { get; set; }
    }
}
