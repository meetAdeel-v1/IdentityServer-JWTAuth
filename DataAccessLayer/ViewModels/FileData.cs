using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.ViewModels
{
    public class FileData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public string ConentType { get; set; }
        public byte[] FileGuid { get; set; }
    }
}
