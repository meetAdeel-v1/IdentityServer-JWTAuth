using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interface;
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
        public readonly IFileRepository _fileRepository;
        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public async Task<FileData> getFile(string userId)
        {
            return await _fileRepository.getFile(userId);
        }

        public Task<List<UserFileData>> getFiles()
        {
            throw new NotImplementedException();
        }

        public Task<FileData> saveFile(UserFileData file)
        {
            var result = _fileRepository.saveFile(file);
            return result;
        }

        public Task<List<UserFileData>> saveFiles(List<UserFileData> files)
        {
            throw new NotImplementedException();
        }
    }
}
