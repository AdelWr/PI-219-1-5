using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repository;

namespace BLL.Logic
{
    internal class ResumeService : IResumeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IMapper _resumeMapper;

        private IMapper _resumeUpdateMapper;

        private IMapper _vacansyMapper;

        public ResumeService(IUnitOfWork unitOfWork)
        {
            Mapping();
            _unitOfWork = unitOfWork;
        }

        public void AddResume(ResumeDTO resumeDto)
        {
            _unitOfWork.Resumes.Create(new Resume
            {
                Info = resumeDto.Info,
                Position = resumeDto.Position,
                PreferablySalary = resumeDto.PreferablySalary,
                ResumeTitile = resumeDto.ResumeTitile,
                Vacancies = new List<Vacansy>()
            });

            _unitOfWork.Save();
        }


        public void AddVacansyToResume(int id, VacansyDTO vacansyDTO)
        {
            var resume = _unitOfWork.Resumes.GetOne(x => (x.ResumeId == id));

            if (resume != null)
            {
                var vacancy = _vacansyMapper.Map<VacansyDTO, Vacansy>(vacansyDTO);

                _unitOfWork.Vacansies.Create(vacancy);

                resume.Vacancies.Add(vacancy);

                _unitOfWork.Save();
            }
        }

        public ICollection<Vacansy> GetResumesVacancies(int resumeId)
        {
            var resume = _unitOfWork.Resumes.GetOne(x => (x.ResumeId == resumeId));

            if (resume != null)
            {
                return resume.Vacancies;
            }

            return null;
        }

        public ResumeDTO GetResumeByID(int id)
        {
            return _resumeMapper.Map<Resume, ResumeDTO>(_unitOfWork.Resumes.GetOne(x => (x.ResumeId == id)));
        }

        public ICollection<ResumeDTO> Get()
        {
            return _resumeMapper.Map<IEnumerable<Resume>, List<ResumeDTO>>(_unitOfWork.Resumes.Get());
        }

        public void RemoveResumeByID(int id)
        {
            _unitOfWork.Resumes.Remove(_unitOfWork.Resumes.FindById(id));
            _unitOfWork.Save();
        }

        public void UpdateResume(int id, ResumeDTO resumeDto)
        {
            var resumeForUpdate = GetResumeByID(id);

            if (resumeForUpdate != null)
            {
                _unitOfWork.Resumes.Update(_resumeUpdateMapper.Map<ResumeDTO, Resume>(resumeDto));
            }
        }

        private void Mapping()
        {
            _vacansyMapper = new MapperConfiguration(cfg => cfg.CreateMap<VacansyDTO, Vacansy>()).CreateMapper();

            _resumeMapper = new MapperConfiguration(cfg => cfg.CreateMap<Resume, ResumeDTO>()).CreateMapper();

            _resumeUpdateMapper = new MapperConfiguration(cfg => cfg.CreateMap<ResumeDTO, Resume>()
            .ForMember(c => c.Vacancies, x => x.MapFrom(v => v.Vacancies))).CreateMapper();

        }
    }
}
