using Business.Helpers;
using Data.Entities;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class UserService
    {   
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool AddUser(string login, string password)
        {   
            string newHashPassword = ConvertPassHash.ConvertHash(password);
            User chechDublicate = _userRepository.GetUserByName(login);

            if(chechDublicate != null)
            {
                throw new ArgumentException("Такой юзерe уже есть");
            }

            int res = _userRepository.AddUser(new User() { Name = login, Password = newHashPassword });

            if (res == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool AuthUser(string login, string password)
        {
            User res = _userRepository.GetUserByName(login);
            string tmpHashPass = ConvertPassHash.ConvertHash(password);
            if(res == null)
            {
                return false;
            }
            if(tmpHashPass != res.Password)
            {
                return false;
            }
            return true;
        }
    }
}
