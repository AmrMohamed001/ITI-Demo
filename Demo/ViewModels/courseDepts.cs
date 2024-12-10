using Demo.Models;

namespace Demo.ViewModels
{
    public class courseDepts
    {
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Name { get; set; }
        public List<Course> courses { get; set; }
        public List<Department> departments { get; set; }
    }
}
