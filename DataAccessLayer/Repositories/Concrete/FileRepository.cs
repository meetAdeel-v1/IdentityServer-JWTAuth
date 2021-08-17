using DataAccessLayer.DataContext;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interface;
using DataAccessLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public Task<FileData> saveFile(UserFileData file)
        {
            throw new NotImplementedException();
        }

        public Task<List<FileData>> saveFiles(List<UserFileData> files)
        {
            throw new NotImplementedException();
        }
    }
}
