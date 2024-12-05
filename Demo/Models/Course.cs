using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Degree { get; set; }
        public decimal MinDegree { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public List<CrsResult>? CrsResults { get; set; }
        public List<Instructor>? Instructors { get; set; }
    }
}
