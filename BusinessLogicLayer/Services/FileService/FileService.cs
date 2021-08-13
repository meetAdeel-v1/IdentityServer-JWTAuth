using DataAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.FileService
{
    public class FileService : IFileService
    {
        public Task<UserFileData> getFile()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserFileData>> getFiles()
        {
            throw new NotImplementedException();
        }

        public Task<UserFileData> saveFile(UserFileData file)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserFileData>> saveFiles(List<UserFileData> files)
        {
            throw new NotImplementedException();
        }
    }
}
