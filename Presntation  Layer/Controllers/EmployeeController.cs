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
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public EmployeeController(/*IEmployeeRepository employeeRepository , IDepartmentRepository departmentRepository */ IUnitOfWork unitOfWork, IMapper mapper)
        {
            //_departmentRepository = departmentRepository;
            //_employeeRepository = employeeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string? searchInput)
        {
            var employees =await _unitOfWork.employeeRepository.GetAllAsync();
            if(!string.IsNullOrEmpty(searchInput))
            {
                employees = await _unitOfWork.employeeRepository.GetByNameAsync(searchInput);
                return View(employees);
            }
            return View(employees);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var departments =await _unitOfWork.departmentRepository.GetAllAsync();
            ViewData["Departments"] = departments;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee model)
        {
            if (ModelState.IsValid)
            {

                var cnt = await _unitOfWork.employeeRepository.AddAsync(model);
                if (cnt > 0) return RedirectToAction("Index");

            }
            ViewData["Departments"] = await _unitOfWork.departmentRepository.GetAllAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var employee = await _unitOfWork.employeeRepository.GetAsync(id);
            TempData["EmployeeId"] = id;
            var model = _mapper.Map<DetailsEmployeeDTO>(employee);
            if (employee == null) return NotFound();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var employee =await _unitOfWork.employeeRepository.GetAsync(id);
            if (employee == null) return NotFound();
            ViewData["Departments"] = await _unitOfWork.departmentRepository.GetAllAsync();

            var model = _mapper.Map<UpdateEmployeeDTO>(employee);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDTO model)
        {
            if (ModelState.IsValid)
            {
                ViewData["Departments"] = await _unitOfWork.departmentRepository.GetAllAsync();
                var employee = await _unitOfWork.employeeRepository.GetAsync(id);
                if (employee == null) return NotFound();

                _mapper.Map(model, employee);

                var cnt = _unitOfWork.employeeRepository.Update(employee);
                if (cnt > 0) return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _unitOfWork.employeeRepository.GetAsync(id);
            if (employee == null) return NotFound();
            ViewData["Departments"] = await _unitOfWork.departmentRepository.GetAllAsync();
            var model = _mapper.Map<DeleteEmployeeDTO>(employee);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteEmployeeDTO model)
        {
            ViewData["Departments"] = await _unitOfWork.departmentRepository.GetAllAsync();
            var employee = await _unitOfWork.employeeRepository.GetAsync(id);
            if (employee == null) return NotFound();
            var cnt = _unitOfWork.employeeRepository.Delete(employee);
            if (cnt > 0) return RedirectToAction("Index");
            return View(model);
        }
    }
}
