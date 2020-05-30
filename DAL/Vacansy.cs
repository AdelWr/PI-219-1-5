using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Vacansies")]
    public class Vacansy
    {
        [Key]
        public int VacansyId { get; set; }

        public string VacansyTitle { get; set; }

        public string VacansyPosition { get; set; }

        public string VacansyInfo { get; set; }

        public double VacansySalary { get; set; }

        public virtual ICollection<Resume> Resumes { get; set; }
    }
}
