using Data.Entities;
using Data.Repositories;

namespace AexSoftTest.Data.Tests
{
    public class UserRepositoryTests
    {
        private UserRepository _testRepository;
        private User _testUser;

        [SetUp]
        public void Setup()
        {
            _testRepository = new UserRepository();
            RestartDB();

            _testUser = new User()
            {
                Name = "UserTest1",
                Password = "Qwerty1"
            };
        }

        [Test]
        public void AddUserTest()
        {
            //given
            int expected = 1; // Successful execution

            ////when
            int actual = _testRepository.AddUser(_testUser);

            ////then 
            Assert.NotNull(actual);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GetUserByNameTest_WhenUserIsInDatabase()
        {
            //given
            int expectedId = 1; //  execution id
            _testRepository.AddUser(_testUser);

            ////when

            User actual = _testRepository.GetUserByName(_testUser.Name);

            ////then 
            Assert.NotNull(actual);
            Assert.AreEqual(expectedId, actual.Id);
            Assert.AreEqual(_testUser.Name, actual.Name);
            Assert.AreEqual(_testUser.Password, actual.Password);
        }

        [Test]
        public void GetUserByNameTest_WhenUserIsNotInDatabase()
        {
            //given
            _testRepository.AddUser(_testUser);

            ////when
            User actual = _testRepository.GetUserByName("Владимир");

            ////then 
            Assert.Null(actual);
        }

        private void RestartDB()
        {
            _testRepository = new UserRepository();
            _testRepository.Droptable();
            _testRepository = new UserRepository();
        }
    }
}
