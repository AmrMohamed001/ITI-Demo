using Demo.Models;
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
        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
