using DAL.Models;

namespace DAL.Repository
{
    public interface IUnitOfWork
    {
        IGenericRepository<User> Users { get; set; }

        IGenericRepository<Resume> Resumes { get; set; }

        IGenericRepository<Vacansy> Vacansies { get; set; }

        void Save();

        void Dispose();
    }
}
