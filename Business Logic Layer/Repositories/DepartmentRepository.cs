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

        public async Task<int> AddAsync(Department department)
        {
            await _context.Departments.AddAsync(department);
            return _context.SaveChanges();
        }

        public async Task<Department> GetAsync(int id)
        {
            var dep = await _context.Departments.FindAsync(id);
            return dep;
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
             var dep = await _context.Departments.ToListAsync();
            return dep;
        }

        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        public async Task<IEnumerable<Department>> GetByNameAsync(string searchInput)
        {
            var dep = await _context.Departments.Where(D => D.Name.ToLower().Contains(searchInput.ToLower())).ToListAsync();
            return dep;
        }
    }
}
