using DataAccessLayer.Models;
using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interface
{
    public interface IFileRepository
    {
        Task<FileData> saveFile(UserFileData file);
        Task<List<FileData>> saveFiles(List<UserFileData> files);
        Task<FileData> getFile(string fileId);
        Task<IEnumerable<FileData>> getFiles();
    }
}
