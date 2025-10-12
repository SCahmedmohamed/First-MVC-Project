using Business_Logic_Layer.InterFaces;
using Data_Access_Layer.DbContexts;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly CompanyDbcontext _context;
        public DepartmentRepository(CompanyDbcontext context)
        { 
            _context = context;
        }

        public int Delete(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }

        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }

        public Department Get(int id)
        {
            var dep = _context.Departments.Find(id);
            return dep;
        }

        public IEnumerable<Department> GetAll()
        {
             var dep =  _context.Departments.ToList();
            return dep;
        }

        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        public IEnumerable<Department> GetByName(string searchInput)
        {
            var dep = _context.Departments.Where(D => D.Name.ToLower().Contains(searchInput.ToLower())).ToList();
            return dep;
        }
    }
}
