using Demo.Models;

namespace Demo.Repositories.Interfaces
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
    }
}
