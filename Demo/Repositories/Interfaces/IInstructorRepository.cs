using Demo.Models;

namespace Demo.Repositories.Interfaces
{
    public interface IInstructorRepository
    {
        public void Create(Instructor obj);
        public List<Instructor> GetAll();
        public Instructor GetOne(int id);
        public void Update(Instructor obj);
        public void Delete(int id);
        public void Save();
    }
}
