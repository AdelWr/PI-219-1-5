using BLL.DTO;
using DAL.Models;
using System.Collections.Generic;

namespace BLL.Logic
{
    public interface IResumeService
    {
        ICollection<ResumeDTO> Get();

        ResumeDTO GetResumeByID(int id);

        void AddResume(ResumeDTO resumeDto);

        void UpdateResume(int id, ResumeDTO resumeDto);

        void RemoveResumeByID(int id);

        void AddVacansyToResume(int id, VacansyDTO vacansyDTO);

         ICollection<Vacansy> GetResumesVacancies(int resumeId);
       
    }
}
