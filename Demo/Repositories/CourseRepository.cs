using Demo.Models;
using Demo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class CourseRepository : ICourseRepository

    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Course obj)
        {
            _context.Add(obj);
        }

        public void Delete(int id)
        {
            var crs = this.GetOne(id);
            _context.Remove(crs);
        }

        public List<Course> GetAll()
        {
            return _context.courses.Include(x => x.Department).ToList();
        }

        public Course GetOne(int id)
        {
            return _context.courses.Include(x => x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Course obj)
        {
            _context.Update(obj);
        }
    }
}
