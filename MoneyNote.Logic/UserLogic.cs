using AutoMapper;
using MoneyNote.DbModels;
using MoneyNote.DomainModel;
using MoneyNote.IRepository;
using MoneyNote.Repository;
using System;
using System.Linq;

namespace MoneyNote.Logic
{
    public class UserLogic
    {
        private readonly IRepository<UserDto> userRepository;
        private IMapper mapper;
        public UserLogic(IRepository<UserDto> db, IMapper mapper)
        {
            this.userRepository = db;
            this.mapper = mapper;
        }
        public UserModel Login(LoginModel loginModel)
        {
            var user = userRepository.Get().FirstOrDefault(p => p.EMail == loginModel.EMail);
            return mapper.Map<UserModel>(user);
        }
        public UserModel Regist(RegistModel registModel)
        {
            var user = mapper.Map<UserDto>(registModel);
            user = userRepository.Insert(user);
            return mapper.Map<UserModel>(user);
        }
    }
}
