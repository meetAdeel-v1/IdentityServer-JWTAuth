using DataAccessLayer.DataContext;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interface;
using DataAccessLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Concrete
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationContext _dataContext;
        public FileRepository(ApplicationContext appContext)
        {
            _dataContext = appContext;
        }
        public async Task<FileData> getFile(int fileId)
        {
            return await _dataContext.Files.FirstOrDefaultAsync(f=> f.Id==fileId);
        }

        public async Task<IEnumerable<FileData>> getFiles()
        {
            return await _dataContext.Files.ToListAsync();
        }

        public async Task<FileData> saveFile(UserFileData file)
        {
            var _file = new FileData();
            _file.Name = file.Name;
            _file.FileName = file.FileName;
            _file.ConentType = file.ConentType;
            _file.FileGuid = file.FileGuid;
            _dataContext.Add(_file);
            var result = await _dataContext.SaveChangesAsync();
            var _fileManager = new FileManagement();
            //_fileManager.FileId = file.fileManagerInfo.fileId;
            _fileManager.FileId = result;
            _fileManager.UserId = file.UserId;
            _fileManager.FileTypeId = file.fileType;
            return _file;
        }

        public Task<List<FileData>> saveFiles(List<UserFileData> files)
        {
            throw new NotImplementedException();
        }
    }
}
