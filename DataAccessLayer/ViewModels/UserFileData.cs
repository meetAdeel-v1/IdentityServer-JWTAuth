using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class UserFileData {
        //file data
        public string Name { get; set; }
        public string FileName { get; set; }
        public string ConentType { get; set; }
        public byte[] FileGuid { get; set; }
        //fileManager Data
        public int fileId { get; set; }
        public string UserId { get; set; }
        public string fileType { get; set; }

    }
}
