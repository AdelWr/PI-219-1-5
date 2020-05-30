using System.Collections.Generic;
using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL.Repository;

namespace BLL.Logic
{
    internal class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private IMapper _userMapper;

        private IMapper _userUpdateMapper;

        public UserService(IUnitOfWork unitOfWork)
        {
            Mapping();
            _unitOfWork = unitOfWork;
        }

        public void Add(UserDTO userDto)
        {
            _unitOfWork.Users.Create(new User { Company = userDto.Company, Name = userDto.Name, Login = userDto.Login, Pass = userDto.Pass, Role = userDto.Role });
            _unitOfWork.Save();
        }

        public UserDTO GetByID(int id)
        {
            return _userMapper.Map<User, UserDTO>(_unitOfWork.Users.GetOne(x => (x.UserId == id)));
        }

        public ICollection<UserDTO> Get()
        {
            return _userMapper.Map<IEnumerable<User>, List<UserDTO>>(_unitOfWork.Users.Get());
        }

        public void RemoveByID(int id)
        {
            _unitOfWork.Users.Remove(_unitOfWork.Users.FindById(id));
            _unitOfWork.Save();
        }

        public void Update(int id, UserDTO userDto)
        {
            var userForUpdate = GetByID(id);

            if (userForUpdate != null)
            {
                _unitOfWork.Users.Update(_userUpdateMapper.Map<UserDTO, User>(userDto));
            }
        }

        private void Mapping()
        {
            _userMapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()
            .ForMember(x => x.Role, y => y.MapFrom(c => c.Role))
            .ForMember(x => x.Resume, y => y.MapFrom(c => c.Resume))).CreateMapper();

            _userUpdateMapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()
            .ForMember(x => x.Role, y => y.MapFrom(c => c.Role))
            .ForMember(x => x.Resume, y => y.MapFrom(c => c.Resume))).CreateMapper();
        }
    }
}
