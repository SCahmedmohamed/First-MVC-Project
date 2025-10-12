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
        private IMapper _mapper;

        public DepartmentController(IDepartmentRepository departmentRepository , IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public IActionResult Index(string? searchInput) 
        {
            var departments = _departmentRepository.GetAll();
            if (!string.IsNullOrEmpty(searchInput))
            {
                departments = _departmentRepository.GetByName(searchInput);
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
        public IActionResult Create(CreateDepartmentDTO model)
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
               var cnt = _departmentRepository.Add(department);
                if (cnt > 0) return RedirectToAction("Index");

            }
           return View(model);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentRepository.Get(id);
            TempData["deptId"] = id;
            var model = _mapper.Map<DetailsDepartmentDTO>(department);
            if (department == null) return NotFound();
            return View(model);
        }

        [HttpGet]

        public IActionResult Update(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null) return NotFound();
            var model = _mapper.Map<UpdateDepartmentDTO>(department);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateDepartmentDTO model)
        {
            if (ModelState.IsValid)
            {
                var department = _departmentRepository.Get(id);
                if (department == null) return NotFound();
                _mapper.Map(model, department);

                var cnt = _departmentRepository.Update(department);
                if (cnt > 0) return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var department = _departmentRepository.Get(id);
            if (department == null) return NotFound();
            var model = _mapper.Map<DeleteDepartmentDTO>(department);
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id, DeleteDepartmentDTO model)
        {
            var department = _departmentRepository.Get(id);
            if (department == null) return NotFound();
            var cnt = _departmentRepository.Delete(department);
            if (cnt > 0) return RedirectToAction("Index");
            return View(model);
        }

    }
}
