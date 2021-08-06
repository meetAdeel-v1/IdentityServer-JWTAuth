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
        Task<FileData> saveFile(FileData file);
        Task<List<FileData>> saveFiles(List<FileData> files);
        Task<FileData> getFile();
        Task<FileData> getFiles();
    }
}
