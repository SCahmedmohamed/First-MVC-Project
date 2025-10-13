using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.InterFaces
{
    public interface IUnitOfWork
    {
        IDepartmentRepository departmentRepository { get; }
        IEmployeeRepository employeeRepository { get; }
    }
}
