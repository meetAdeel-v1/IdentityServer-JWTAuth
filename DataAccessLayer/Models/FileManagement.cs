using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class FileManagement
    {
        [Key]
        public int Id { get; set; }
        public int FileId { get; set; }
        public string UserId { get; set; }
        public string FileTypeId { get; set; }
    }
}
