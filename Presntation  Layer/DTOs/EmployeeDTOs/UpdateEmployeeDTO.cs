using Data_Access_Layer.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Presntation__Layer.DTOs.EmployeeDTOs
{
    public class UpdateEmployeeDTO
    {
        [Required(ErrorMessage ="Code Is Required")]
        public int Code { get; set; }
        [Required(ErrorMessage ="Name Is Required")] 
        public string Name { get; set; }
        [Required(ErrorMessage ="Email Is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage ="PhoneNumber Is Required")]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage ="Hire Date Is Required")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage ="Salary Is Required")]
        public decimal Salary { get; set; }
        [DisplayName("Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
