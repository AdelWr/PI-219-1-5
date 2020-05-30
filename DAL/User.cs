using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public string Role { get; set; }

        public int? ResumeId { get; set; }

        public string Company { get; set; }

        [ForeignKey("ResumeId")]
        public virtual Resume Resume { get; set; }
    }
}
