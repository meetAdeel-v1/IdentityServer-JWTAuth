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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> multipleFilesUpload(IEnumerable<IFormFile> files)
        {
            long totalFilesSize = files.Sum(f => f.Length);
            var filePaths = new List<string>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    filePaths.Add(filePath);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { filesCount = files.Count(), totalSize = totalFilesSize, filePaths });
        }
    }
}
