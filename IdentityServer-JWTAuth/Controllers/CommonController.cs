using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer_JWTAuth.Controllers
{
    public class CommonController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task<IActionResult> fileUpload(IFormFile file)
        {
            long fileSize = file.Length;
            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath,FileMode.Create)) 
            {
                await file.CopyToAsync(stream);
            }
            return Ok();
        }
    }
}
