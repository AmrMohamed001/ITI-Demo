using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class CrsResult
    {
        public int Id { get; set; }
        public decimal degree { get; set; }
        [ForeignKey("Trainee")]
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}
