using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "Name Must Be Less than 20 Char")]
        [MinLength(2, ErrorMessage = "Name Must Be More than 2 Char")]
        [Unique]
        public string Name { get; set; }

        [Required]
        [Remote(action: "checkDegree", controller: "course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than Degree")]
        public decimal MinDegree { get; set; }
        [Required]
        [Range(50, 100)]
        public decimal Degree { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public List<CrsResult>? CrsResults { get; set; }
        public List<Instructor>? Instructors { get; set; }
    }
}
