using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Resumes")]
    public class Resume
    {
        [Key]
        public int ResumeId { get; set; }

        public string ResumeTitile { get; set; }
        
        public string Position { get; set; }

        public double PreferablySalary { get; set; }

        public string Info { get; set; }

        public virtual ICollection<Vacansy> Vacancies { get; set; }

    }
}
