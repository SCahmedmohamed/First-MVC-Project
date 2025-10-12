using AutoMapper;
using Business_Logic_Layer.InterFaces;
using Business_Logic_Layer.Repositories;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Presntation__Layer.DTOs.EmployeeDTOs;

namespace Presntation__Layer.Controllers
{
    public class EmployeeController : Controller
    {
        private IDepartmentRepository _departmentRepository;
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;

        public EmployeeController(IEmployeeRepository employeeRepository , IDepartmentRepository departmentRepository , IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index(string? searchInput)
        {
            var employees = _employeeRepository.GetAll();
            if(!string.IsNullOrEmpty(searchInput))
            {
                employees = _employeeRepository.GetByName(searchInput);
                return View(employees);
            }
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var departments = _departmentRepository.GetAll();
            ViewData["Departments"] = departments;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee model)
        {
            if (ModelState.IsValid)
            {

                var cnt = _employeeRepository.Add(model);
                if (cnt > 0) return RedirectToAction("Index");

            }
            ViewData["Departments"] = _departmentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.Get(id);
            TempData["EmployeeId"] = id;
            var model = _mapper.Map<DetailsEmployeeDTO>(employee);
            if (employee == null) return NotFound();
            return View(model);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null) return NotFound();
            ViewData["Departments"] = _departmentRepository.GetAll();

            var model = _mapper.Map<UpdateEmployeeDTO>(employee);

            return View(model);
        }
        [HttpPost]
        public IActionResult Update(int id, UpdateEmployeeDTO model)
        {
            if (ModelState.IsValid)
            {
                ViewData["Departments"] = _departmentRepository.GetAll();
                var employee = _employeeRepository.Get(id);
                if (employee == null) return NotFound();

                _mapper.Map(model, employee);

                var cnt = _employeeRepository.Update(employee);
                if (cnt > 0) return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null) return NotFound();
            ViewData["Departments"] = _departmentRepository.GetAll();
            var model = _mapper.Map<DeleteEmployeeDTO>(employee);

            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id, DeleteEmployeeDTO model)
        {
            ViewData["Departments"] = _departmentRepository.GetAll();
            var employee = _employeeRepository.Get(id);
            if (employee == null) return NotFound();
            var cnt = _employeeRepository.Delete(employee);
            if (cnt > 0) return RedirectToAction("Index");
            return View(model);
        }
    }
}
