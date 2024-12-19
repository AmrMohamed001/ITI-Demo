using Demo.Models;
using Demo.Repositories.Interfaces;

namespace Demo.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;
        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Department> GetAll()
        {
            return _context.departments.ToList();
        }
    }
}
