using BLL.Logic;
using DAL.Dependencies;
using DAL.Repository;
using Ninject;
using Ninject.Modules;

namespace BLL.Dependencies
{
    public class NinjectBusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            var unitOfWork = new StandardKernel(new DataAccessModule()).Get<IUnitOfWork>();
            Bind<IVacansyService>().ToConstructor(x => new VacansyService(unitOfWork));
            Bind<IUserService>().ToConstructor(x => new UserService(unitOfWork));
            Bind<IResumeService>().ToConstructor(x => new ResumeService(unitOfWork));
        }
    }
}
