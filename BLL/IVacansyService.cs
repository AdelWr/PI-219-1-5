using BLL.DTO;
using DAL.Models;
using System.Collections.Generic;

namespace BLL.Logic
{
    public interface IVacansyService
    {
        ICollection<VacansyDTO> Get();

        VacansyDTO GetID(int id);

        void Add(VacansyDTO vacansyDto);

        void Update(int id, VacansyDTO vacansyDto);

        void RemoveByID(int id);
    }
}
