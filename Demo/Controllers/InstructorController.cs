using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    public class InstructorController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            List<Instructor> instructors = _context.instructors.Include(i => i.Department).Include(x => x.Course).ToList();
            return View("Index", instructors);
        }
        public IActionResult Add()
        {
            var departments = _context.departments.ToList();
            var courses = _context.courses.ToList();
            var courseDept = new courseDepts()
            {
                courses = courses,
                departments = departments
            };
            return View("add", courseDept);
        }
        public IActionResult save(Instructor instructorObj)
        {
            if (instructorObj.Salary == null || instructorObj.Name == null || instructorObj.CourseId == null || instructorObj.DepartmentId == null) return RedirectToAction("Add");
            var newInstructor = _context.instructors.Add(instructorObj);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            var instructor = _context.instructors.Include(x => x.Course).Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            var courseDeptInstrucor = new courseDeptInstructor()
            {
                Name = instructor.Name,
                Salary = instructor.Salary,
                Address = instructor.Address,
                Course = instructor.Course,
                Department = instructor.Department
            };
            return View("details", courseDeptInstrucor);
        }

    }
}
