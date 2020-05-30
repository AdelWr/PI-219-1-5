using DAL.Models;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class VacansyDTO
    {
        public int VacansyId { get; set; }

        public string VacansyTitle { get; set; }

        public string VacansyPosition { get; set; }

        public string VacansyInfo { get; set; }

        public double VacansySalary { get; set; }

        public virtual ICollection<Resume> Resumes { get; set; }
    }
}
