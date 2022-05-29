using Business.Services;
using Data.Repositories;

namespace AexSoftTest.Business.Tests
{
    public class UserServiceTests
    {
        private UserService _testUserService;
        private UserRepository _testUserRepository;

        [SetUp]
        public void Setup()
        {
            _testUserService = new UserService();
            RestartDB();
        }

        [Test]
        public void AddUserTest()
        {
            //given
            string login = "user1";
            string password = "qwerty1";

            ////when
            bool actual = _testUserService.AddUser(login, password);

            ////then 
            Assert.NotNull(actual);
            Assert.IsTrue(actual);
        }

        [Test]
        public void AuthUser_WhenLoginAndPassIsTrue()
        {
            //given
            string login = "user1";
            string password = "qwerty1";
            _testUserService.AddUser(login, password);

            ////when
            bool actual = _testUserService.AuthUser(login, password);

            ////then 
            Assert.NotNull(actual);
            Assert.IsTrue(actual);
        }

        [Test]
        public void AuthUser_WhenLoginAndPassIsFalse()
        {
            //given
            string login = "user1";
            string password = "qwerty1";
            string loginNotActual = "user2";

            _testUserService.AddUser(login, password);

            ////when
            bool actual = _testUserService.AuthUser(loginNotActual, password);

            ////then 
            Assert.NotNull(actual);
            Assert.IsFalse(actual);
        }


        private void RestartDB()
        {
            _testUserRepository = new UserRepository();
            _testUserRepository.Droptable();
            _testUserRepository = new UserRepository();
        }
    }
}
