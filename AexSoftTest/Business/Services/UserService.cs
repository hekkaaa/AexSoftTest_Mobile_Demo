using Business.Helpers;
using Data.ConnectDb;
using Data.Entities;
using Data.Repositories;
using System;

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

            if (chechDublicate != null)
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
                ConnectSettings.RenameDatabaseUser(login.ToLower());
                return true;
            }
        }

        public bool AuthUser(string login, string password)
        {
            User res = _userRepository.GetUserByName(login);
            string tmpHashPass = ConvertPassHash.ConvertHash(password);

            if (res == null)
            {
                return false;
            }
            if (tmpHashPass != res.Password)
            {
                return false;
            }

            ConnectSettings.RenameDatabaseUser(login.ToLower());
            return true;
        }
    }
}
