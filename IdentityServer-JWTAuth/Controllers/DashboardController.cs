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
        public async Task<IActionResult> RenderImage(string userId)
        {
            userId = "35cc693a-62d3-4f59-840c-d5f0e5147bf8";
            //get from _fileservice
            var result =await _fileService.getFile(userId);
            //write read into byt[] stream
            //return File(stream,format,DisplayName);
            //var stream = new FileStream(@"pathToFile", FileMode.Open);
            return File(result.FileGuid, result.ContentType, result.FileName);
        }

    }
}
