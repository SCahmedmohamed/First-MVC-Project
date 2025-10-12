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

        public IEnumerable<Employee> GetByName(string searchInput)
        {
            var emp = _context.Employees.Include(E => E.Department).Where(E => E.Name.ToLower().Contains(searchInput.ToLower())).ToList();
            return emp;
        }

        public int Add(Employee employee)
        {
            _context.Employees.Add(employee);
            return _context.SaveChanges();
        }

        public Employee Get(int id)
        {
            var emp = _context.Employees.Include(E=>E.Department).FirstOrDefault(E=>E.Id == id);
            return emp;
        }

        public IEnumerable<Employee> GetAll()
        {
            var emp = _context.Employees.Include(e=> e.Department).ToList();
            return emp;
        }

        public int Update(Employee employee)
        {
            _context.Employees.Update(employee);
            return _context.SaveChanges();
        }
    }
}
