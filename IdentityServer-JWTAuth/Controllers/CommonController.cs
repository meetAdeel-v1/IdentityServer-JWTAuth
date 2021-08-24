using BusinessLogicLayer.Services.FileService;
using DataAccessLayer.ViewModels;
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
        public readonly IFileService _fileService;
        public CommonController(IFileService fileService)
        {
            _fileService = fileService;
        }
        public ActionResult Index()
        {
            return View();
        }
        //public async Task<ActionResult> UploadDocument([FromForm] DataWrapper data)
        //{
        //    IFormFile file = data.File;

        //    long length = file.Length;
        //    if (length < 0)
        //        return BadRequest();

        //    using var fileStream = file.OpenReadStream();
        //    byte[] bytes = new byte[length];
        //    fileStream.Read(bytes, 0, (int)file.Length);

        //}
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> fileUpload(IFormFile file)
        {
            long fileSize = file.Length;
            byte[] byteArr = null;
            //var filePath = Path.GetTempFileName();
            //byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            using (var stream=new MemoryStream())
            {
                await file.CopyToAsync(stream);
                byteArr = stream.ToArray();
            }
            var fileObj = new UserFileData();
            fileObj.filesInfo.Name = file.Name;
            fileObj.filesInfo.FileName = file.FileName;
            fileObj.filesInfo.ConentType = file.ContentType;
            fileObj.filesInfo.FileGuid = byteArr;
            //using (var stream = new FileStream(filePath,FileMode.Create)) 
            //{
            //    await file.CopyToAsync(stream);
            //}
            var result = await _fileService.saveFile(fileObj);
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
        [HttpGet]
        public async Task<IActionResult> getFile()
        {
            var temp = Path.GetTempFileName();
            var result = await _fileService.getFile();
            System.IO.File.WriteAllBytes(temp,result.filesInfo.FileGuid);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getMultipleFiles()
        {
            var temp = Path.GetTempFileName();
            var result = await _fileService.getFiles();
            foreach(var file in result)
            {
                System.IO.File.WriteAllBytes(temp, file.filesInfo.FileGuid);
            }
            return Ok(result);
        }
    }
}
