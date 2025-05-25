using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public int Age { get; set; }
        public int YearsOfService { get; set; }
        public DateTime StartDate { get; set; }
        public int Salary { get; set; }

        public ICollection<Item> Items { get; } = new List<Item>();
    }
}
