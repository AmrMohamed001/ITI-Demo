using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Image { get; set; }
        [Required]
        public decimal Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [ForeignKey("Course")]
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
