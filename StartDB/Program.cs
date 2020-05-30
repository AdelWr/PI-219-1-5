using DAL.Dependencies;
using DAL.Models;
using DAL.Repository;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartDB
{
    class Program
    {
        static void Main(string[] args)
        {

            var kernel = new StandardKernel(new DataAccessModule());

            var data = kernel.Get<IUnitOfWork>();

            var vacansy = new Vacansy { VacansyTitle = "Middle .Net developer", VacansyInfo = "Looking for middle .net developer", VacansyPosition = "Middle", VacansySalary = 2100, Resumes = new List<Resume>() };
            var resume = new Resume { ResumeTitile = ".Net developer", Position = "Middle", ResumeId = 1, Info = "Looking for a good job", PreferablySalary = 2000, Vacancies = new List<Vacansy>() };
            resume.Vacancies.Add(vacansy);
            vacansy.Resumes.Add(resume);
            data.Save();

            data.Users.Create(new User { Login = "Admin", Pass = "Admin", Role = "Admin" });
            var employee = new User { UserId = 2, Login = "Employee", Pass = "Employee", Role = "Employee", Name = "UserName", Company = "", Surname = "UserSurname", Patronymic = "UserPatronymic", Resume = resume, ResumeId = resume.ResumeId };
            data.Users.Create(employee);
            data.Users.Create(new User { Login = "Employer", Company = "Luxoft", Pass = "Employer", Role = "Employer" });

            data.Resumes.Create(resume);
            data.Vacansies.Create(vacansy);
            data.Save();
        }
    }
}
