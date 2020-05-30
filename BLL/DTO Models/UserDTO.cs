using DAL.Models;
using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronymic { get; set; }

        public string Login { get; set; }

        public string Pass { get; set; }

        public string Company { get; set; }

        public string Role { get; set; }

        public int? ResumeId { get; set; }

        public virtual Resume Resume { get; set; }
    }
}