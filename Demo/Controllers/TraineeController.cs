using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    public class TraineeController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        public IActionResult ShowResult(int Id, int crsId)
        {
            var trainee = _context.trainees.Include(x => x.crsResults).FirstOrDefault(x => x.Id == Id);
            var crsResult = trainee.crsResults.FirstOrDefault(x => x.CourseId == crsId);
            var course = _context.courses.FirstOrDefault(x => x.Id == crsId);
            var TraineeResult = new StudentResult
            {
                Name = trainee.Name,
                CrsName = course.Name,
                Degree = crsResult.degree,
                Color = (crsResult.degree >= course.MinDegree) ? "Green" : "Red",
                State = (crsResult.degree >= course.MinDegree) ? "Success" : "failed"
            };
            return View("sho" +
                "wResult", TraineeResult);
        }
        public IActionResult ShowCourseResult(int Id)
        {
            var course = _context.courses.FirstOrDefault(x => x.Id == Id);
            var crsResults = _context.crsResults.Where(x => x.CourseId == Id).Include(x => x.Trainee).ToList();
            List<StudentResult> result = new List<StudentResult>();
            foreach (var item in crsResults)
            {
                var x = new StudentResult()
                {
                    Name = item.Trainee.Name,
                    Degree = item.degree,
                    CrsName = course.Name,
                    Color = (item.degree >= course.MinDegree) ? "Green" : "Red",
                    State = (item.degree >= course.MinDegree) ? "Success" : "failed"
                };
                result.Add(x);
            }
            return View("ShowCourseResult", result);
        }
    }
}
