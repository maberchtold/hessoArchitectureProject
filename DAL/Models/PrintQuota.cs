using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class PrintQuota
    {
        public int Id { get; set; }
        public string? UID { get; set; }        // used by Epurse
        public string? Username { get; set; }   // used by Faculty
        public int NbPages { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
