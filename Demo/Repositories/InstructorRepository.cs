using Demo.Models;
using Demo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _context;
        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Instructor obj)
        {
            _context.Add(obj);
        }

        public void Delete(int id)
        {
            var crs = this.GetOne(id);
            _context.Remove(crs);
        }

        public List<Instructor> GetAll()
        {
            return _context.instructors.Include(i => i.Department).Include(x => x.Course).ToList();
        }

        public Instructor GetOne(int id)
        {
            return _context.instructors.Include(x => x.Course).Include(x => x.Department).FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Instructor obj)
        {
            _context.Update(obj);
        }
    }
}
