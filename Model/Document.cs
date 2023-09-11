using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Document
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string? FileName { get; set; }
        public string? FileType { get; set; }
        public string? FilePath { get; set; }
        public DateTime? CreationDate { get; set; }= DateTime.Now;
        public string? Title { get; set; }
        public string? Description { get; set; }
        public virtual Users User { get; set; } = null!;
    }
}
