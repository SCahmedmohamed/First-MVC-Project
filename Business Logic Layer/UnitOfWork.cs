using Business_Logic_Layer.InterFaces;
using Business_Logic_Layer.Repositories;
using Data_Access_Layer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class UnitOfWork : IUnitOfWork
    {
        private CompanyDbcontext _context;

        public IDepartmentRepository departmentRepository { get; }

        public IEmployeeRepository employeeRepository { get; }


        public UnitOfWork(CompanyDbcontext context)
        {
            _context = context;
            departmentRepository = new DepartmentRepository(_context);
            employeeRepository = new EmployeeRepository(_context);

        }
    }
}
