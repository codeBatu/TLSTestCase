using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO
{
    public class DocumentDTO
    {
        public int ID { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }

        public int UserID { get; set; }
    }
}
