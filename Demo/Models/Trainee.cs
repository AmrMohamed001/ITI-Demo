using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public decimal grade { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        List<CrsResult> crsResults { get; set; }
    }
}
