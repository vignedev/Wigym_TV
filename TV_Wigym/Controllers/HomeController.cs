using System;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using TV.Helpers;
using TV.Models;

namespace TV.Controllers
{
    public class HomeController : Controller
    {
        private readonly WigymTvConfig _config;
        private readonly DisplayData _data;
        private readonly FileHelper _fileHelper;
        private readonly HostingEnvironment _hostingEnvironment;

        public HomeController(HostingEnvironment hostingEnvironment, IOptions<WigymTvConfig> config)
        {
            _hostingEnvironment = hostingEnvironment;
            _config = config.Value;
            _fileHelper = new FileHelper(_config);
            _data = _fileHelper.GetDataFromJson();
        }

        public IActionResult Index()
        {
            return View("View", _data);
        }
        [Route("admin")]
        public IActionResult Admin()
        {
            return View("View", _data);
        }
        [HttpPost]
        public IActionResult OnFileSubmit()
        {
            var file = _fileHelper.TryGetImageFromRequestForm(Request);

            Enum.TryParse(Request.Form["position"], out Position position);
            var image = _fileHelper.SaveImage(file, position, _hostingEnvironment.WebRootPath + _config.ImagesPath);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteImage(int id)
        {
            _fileHelper.DeleteImage(id);
            return RedirectToAction(nameof(Index));
        }
    }
}