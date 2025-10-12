using System.ComponentModel.DataAnnotations;

namespace Presntation__Layer.DTOs.DepartmentDTOs
{
    public class DeleteDepartmentDTO
    {
        [Required(ErrorMessage = "Code Is Required !")]
        public int Code { get; set; }
        [Required(ErrorMessage = "Name Is Required !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Location Is Required !")]
        public string Location { get; set; }
        [Required(ErrorMessage = "The Date Of Creation Is Required !")]
        public DateOnly CreatedAt { get; set; }
    }
}
