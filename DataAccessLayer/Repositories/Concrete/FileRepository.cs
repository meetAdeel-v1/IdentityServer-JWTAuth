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
        public async Task<FileData> getFile(string userId)
        {
            var result = (from FM in _dataContext.FileManagement
                          join FD in _dataContext.FileData on FM.FileId equals FD.Id
                          where FM.UserId == userId && FM.FileTypeId == "ProfileImage"
                          select new FileData {
                              Name=FD.Name,
                              FileName=FD.FileName,
                              ContentType=FD.ContentType,
                              FileGuid=FD.FileGuid
                          }).FirstOrDefault();
            return result;
        }

        public async Task<IEnumerable<FileData>> getFiles()
        {
            return await _dataContext.FileData.ToListAsync();
        }

        public async Task<FileData> saveFile(UserFileData file)
        {
            try
            {
                var _file = new FileData();
                _file.Name = file.Name;
                _file.FileName = file.FileName;
                _file.ContentType = file.ConentType;
                _file.FileGuid = file.FileGuid;
                _dataContext.Add(_file);
                _dataContext.SaveChanges();

                var result = _file.Id;
                var _fileManager = new FileManagement();
                _fileManager.FileId = result;
                _fileManager.UserId = file.UserId;
                _fileManager.FileTypeId = file.fileType;
                _dataContext.Add(_fileManager);
                _dataContext.SaveChanges();

                return  _file;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<List<FileData>> saveFiles(List<UserFileData> files)
        {
            throw new NotImplementedException();
        }
    }
}
