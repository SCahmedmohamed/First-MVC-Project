using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Models
{
    public class Department : BaseEntity
    {

        public string Location { get; set; }
        public DateOnly CreatedAt { get; set; } 
        public List<Employee> Employees { get; set; }
    }
}
