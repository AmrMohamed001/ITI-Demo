using Demo.Models;
using Demo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository Repo;
        private readonly IDepartmentRepository DeptRepo;
        public CourseController(ICourseRepository _repo, IDepartmentRepository deptRepo)
        {
            this.Repo = _repo;
            DeptRepo = deptRepo;
        }
        public IActionResult Index()
        {
            var courses = Repo.GetAll();
            return View("index", courses);
        }

        public IActionResult Add()
        {
            ViewBag.DeptList = DeptRepo.GetAll();
            return View("add");
        }

        public IActionResult Save(Course courseObj)
        {
            if (ModelState.IsValid)
            {
                if (courseObj.DepartmentId != 0)
                {
                    Repo.Create(courseObj);
                    Repo.Save();
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("DepartmentId", "Please select Department");

            }
            ViewBag.DeptList = DeptRepo.GetAll();
            return View("add", courseObj);
        }

        public IActionResult Details(int id)
        {
            var course = Repo.GetOne(id);
            return View("details", course);
        }

        public IActionResult Delete(int id)
        {
            Repo.Delete(id);
            Repo.Save();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var course = Repo.GetOne(id);
            ViewBag.DeptList = DeptRepo.GetAll();
            return View("edit", course);
        }

        public IActionResult SaveEdit(Course courseObj)
        {
            if (ModelState.IsValid)
            {
                if (courseObj.DepartmentId != 0)
                {
                    Repo.Update(courseObj);
                    Repo.Save();
                    return RedirectToAction("index");
                }
                ModelState.AddModelError("DepartmentId", "Please select Department");
            }
            return View("edit", courseObj);

        }

        public IActionResult checkDegree(int minDegree, int degree)
        {
            if (minDegree > degree) return Json(false);
            return Json(true);
        }
    }
}
