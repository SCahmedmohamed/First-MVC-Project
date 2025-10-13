using AutoMapper;
using Business_Logic_Layer.InterFaces;
using Business_Logic_Layer.Repositories;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;
using Presntation__Layer.DTOs.DepartmentDTOs;

namespace Presntation__Layer.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository _departmentRepository;
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public DepartmentController(/*IDepartmentRepository departmentRepository*/IUnitOfWork unitOfWork , IMapper mapper)
        {
            //_departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(string? searchInput) 
        {
            var departments = await _unitOfWork.departmentRepository.GetAllAsync();
            if (!string.IsNullOrEmpty(searchInput))
            {
                departments =await _unitOfWork.departmentRepository.GetByNameAsync(searchInput);
                return View(departments);
            }
            return View(departments);
        } 
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
               Department department = new Department()
                {
                    Code = model.Code,
                    Name = model.Name,
                    Location = model.Location,
                    CreatedAt = model.CreatedAt
                };
               var cnt =await _unitOfWork.departmentRepository.AddAsync(department);
                if (cnt > 0) return RedirectToAction("Index");

            }
           return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var department =await _unitOfWork.departmentRepository.GetAsync(id);
            TempData["deptId"] = id;
            var model = _mapper.Map<DetailsDepartmentDTO>(department);
            if (department == null) return NotFound();
            return View(model);
        }

        [HttpGet]

        public async Task<IActionResult> Update(int id)
        {
            var department =await _unitOfWork.departmentRepository.GetAsync(id);
            if (department == null) return NotFound();
            var model = _mapper.Map<UpdateDepartmentDTO>(department);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateDepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                var department =await _unitOfWork.departmentRepository.GetAsync(id);
                if (department == null) return NotFound();
                _mapper.Map(model, department);

                var cnt = _unitOfWork.departmentRepository.Update(department);
                if (cnt > 0) return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var department =await _unitOfWork.departmentRepository.GetAsync(id);
            if (department == null) return NotFound();
            var model = _mapper.Map<DeleteDepartmentDTO>(department);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, DeleteDepartmentDTO model)
        {
            var department =await _unitOfWork.departmentRepository.GetAsync(id);
            if (department == null) return NotFound();
            var cnt = _unitOfWork.departmentRepository.Delete(department);
            if (cnt > 0) return RedirectToAction("Index");
            return View(model);
        }

    }
}
