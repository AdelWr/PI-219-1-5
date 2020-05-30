using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Logic
{
    public interface IUserService
    {
        ICollection<UserDTO> Get();

        UserDTO GetByID(int id);

        void Add(UserDTO userDto);

        void RemoveByID(int id);

        void Update(int id, UserDTO userDto);
    }
}
