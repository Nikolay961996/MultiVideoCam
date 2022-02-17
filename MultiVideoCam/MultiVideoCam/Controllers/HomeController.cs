using Microsoft.AspNetCore.Mvc;
using MultiVideoCam.Models;
using System.Diagnostics;
using MultiVideoCam.Services.Interfaces;

namespace MultiVideoCam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICamerasService _camerasService;

        public HomeController(ILogger<HomeController> logger, ICamerasService camerasService)
        {
            _logger = logger;
            _camerasService = camerasService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var model = new HomeViewModel
            {
                Cameras = await _camerasService.GetAllCameras(cancellationToken)
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewCam([FromForm]AddNewCamDto dto, CancellationToken cancellationToken)
        {
            await _camerasService.AddNewCamera(dto, cancellationToken);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCamera([FromForm]DeleteCamDto dto, CancellationToken cancellationToken)
        {
            await _camerasService.RemoveCamera(dto, cancellationToken);

            return Ok();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}