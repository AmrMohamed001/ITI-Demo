using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    public class CourseController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        public IActionResult Index()
        {
            var courses = _context.courses.Include(x => x.Department).ToList();
            return View("index", courses);
        }

        public IActionResult Add()
        {
            ViewBag.DeptList = _context.departments.ToList();
            return View("add");
        }

        public IActionResult Save(Course courseObj)
        {
            if (courseObj.Name == null && courseObj.Degree == 0 && courseObj.Department == null)
                return View("add", courseObj);
            _context.courses.Add(courseObj);
            _context.SaveChanges();
            return RedirectToAction("index");

        }

        public IActionResult Details(int id)
        {
            var course = _context.courses.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            return View("details", course);
        }

        public IActionResult Delete(int id)
        {
            var course = _context.courses.FirstOrDefault(x => x.Id == id);
            _context.Remove(course);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var course = _context.courses.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
            ViewBag.DeptList = _context.departments.ToList();
            return View("edit", course);
        }

        public IActionResult SaveEdit(Course courseObj)
        {
            if (courseObj.Name == null && courseObj.Degree == 0 && courseObj.Department == null)
                return View("edit", courseObj);
            _context.courses.Update(courseObj);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
