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
        Task<UserFileData> saveFile(UserFileData file);
        Task<List<UserFileData>> saveFiles(List<UserFileData> files);
        Task<UserFileData> getFile();
        Task<List<UserFileData>> getFiles();
    }
}
