using Demo.Models;

namespace Demo.ViewModels
{
    public class courseDeptInstructor
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }
        public string? Image { get; set; }
        public Department? Department { get; set; }
        public Course? Course { get; set; }
    }
}
