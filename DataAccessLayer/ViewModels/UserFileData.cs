using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class UserFileData {
        public FilesData filesInfo { get; set; }
        public FileManager fileManagerInfo { get; set; }
        
    }
    public class FilesData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string ConentType { get; set; }
        public byte[] FileGuid { get; set; }
    }

    public class FileManager
    {
        public int UserId { get; set; }
        public int fileId { get; set; }
        public string fileType { get; set; }

    }

}
