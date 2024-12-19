using Demo.Models;

namespace Demo.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        public void Create(Course obj);
        public List<Course> GetAll();
        public Course GetOne(int id);
        public void Update(Course obj);
        public void Delete(int id);
        public void Save();

    }
}
