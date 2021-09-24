using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.FileService
{
    public interface IFileService
    {
        Task<FileData> saveFile(UserFileData file);
        Task<List<UserFileData>> saveFiles(List<UserFileData> files);
        Task<FileData> getFile(string userId);
        Task<List<UserFileData>> getFiles();
    }
}
