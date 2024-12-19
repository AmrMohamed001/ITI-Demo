using Demo.Models;

namespace Demo.Repositories.Interfaces
{
    public interface ITraineeRepository
    {
        public void Create(Trainee obj);
        public List<Trainee> GetAll();
        public Trainee GetOne(int id);
        public void Update(Trainee obj);
        public void Delete(int id);
        public void Save();
    }
}
