using DAL.Models;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class ResumeDTO
    {
        public int ResumeId { get; set; }

        public string ResumeTitile { get; set; }

        public string Position { get; set; }

        public double PreferablySalary { get; set; }

        public string Info { get; set; }

        public virtual ICollection<Vacansy> Vacancies { get; set; }
    }
}
