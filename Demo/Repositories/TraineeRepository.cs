using Demo.Models;
using Demo.Repositories.Interfaces;

namespace Demo.Repositories
{
    public class TraineeRepository : ITraineeRepository
    {
        private readonly AppDbContext _context;
        public TraineeRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Create(Trainee obj)
        {
            _context.Add(obj);
        }

        public void Delete(int id)
        {
            var crs = this.GetOne(id);
            _context.Remove(crs);
        }

        public List<Trainee> GetAll()
        {
            return _context.trainees.ToList();
        }

        public Trainee GetOne(int id)
        {
            return _context.trainees.FirstOrDefault(x => x.Id == id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Trainee obj)
        {
            _context.Update(obj);
        }
    }
}
