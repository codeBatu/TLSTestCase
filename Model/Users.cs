using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Users
    {
        public int Id { get; set; }
        public String? Username { get; set; }
        public String? Password { get; set; }
        public String? FirstName { get; set; }
        public String? LastName{ get; set; }

        public virtual ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
