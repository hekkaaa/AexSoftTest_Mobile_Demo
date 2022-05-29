using Business.Services;

namespace TestProject1
{
    public class Tests
    {
        private BookService _bts;

        [SetUp]
        public void Setup()
        {
            _bts = new Business.Services.BookService();
        }

        [Test]
        public void GetBookById()
        {
            var tt = _bts.AddBook(new Business.Models.BookBusinessModel() { Autor = "asdad"});
            Assert.Null(tt);
        }
    }
}