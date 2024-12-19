using Demo.Models;
using Demo.Repositories.Interfaces;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository Repo;
        private readonly ICourseRepository CourseRepo;
        private readonly IDepartmentRepository DeptRepo;
        public InstructorController(IInstructorRepository repo, IDepartmentRepository deptRepo, ICourseRepository courseRepo)
        {
            Repo = repo;
            DeptRepo = deptRepo;
            CourseRepo = courseRepo;
        }
        public IActionResult Index()
        {
            List<Instructor> instructors = Repo.GetAll();
            return View("Index", instructors);
        }
        public IActionResult Add()
        {
            var departments = DeptRepo.GetAll();
            var courses = CourseRepo.GetAll();
            var courseDept = new courseDepts()
            {
                courses = courses,
                departments = departments
            };
            return View("add", courseDept);
        }
        public IActionResult save(Instructor instructorObj)
        {
            if (!ModelState.IsValid) return View("Add", instructorObj);
            if (instructorObj.DepartmentId == 0) ModelState.AddModelError("DepartmentId", "Select Department");
            if (instructorObj.CourseId == 0) ModelState.AddModelError("CourseId", "Select Course");

            Repo.Create(instructorObj);
            Repo.Save();
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            var instructor = Repo.GetOne(id);
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
