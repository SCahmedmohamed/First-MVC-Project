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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CompanyDbcontext _context;
        public EmployeeRepository(CompanyDbcontext context)
        {
            _context = context;
        }

        public int Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            return _context.SaveChanges();
        } 

        public async Task<IEnumerable<Employee>> GetByNameAsync(string searchInput)
        {
            var emp = await _context.Employees.Include(E => E.Department).Where(E => E.Name.ToLower().Contains(searchInput.ToLower())).ToListAsync();
            return emp;
        }

        public async Task<int> AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            return _context.SaveChanges();
        }

        public async Task<Employee> GetAsync(int id)
        {
            var emp = await _context.Employees.Include(E=>E.Department).FirstOrDefaultAsync(E=>E.Id == id);
            return emp;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var emp = await _context.Employees.Include(e=> e.Department).ToListAsync();
            return emp;
        }

        public int Update(Employee employee)
        {
            _context.Employees.Update(employee);
            return _context.SaveChanges();
        }
    }
}
