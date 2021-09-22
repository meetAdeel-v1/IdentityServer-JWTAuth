using BusinessLogicLayer.Services.FileService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer_JWTAuth.Controllers
{
    public class DashboardController : Controller
    {
        public readonly IFileService _fileService;
        public DashboardController(IFileService fileService)
        {
            _fileService = fileService;
        }
        // GET: DashboardController
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        //[Route("getImageFile")]
        public IActionResult RenderImage(int userId)
        {
            //get from db_context
            //write read into byt[] stream
            //return File(stream,format,DisplayName);
            //var stream = new FileStream(@"pathToFile", FileMode.Open);
            return File("stream", "image/png", "imageName.png");
        }

    }
}
