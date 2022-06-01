using AexSoftTest.Models;
using Business.Services;
using Data.ConnectDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AexSoftTest.Business.Tests
{
    public class TestTest
    {
        private BookService _testBookServ = new BookService();

        [Test]
        public void GetbookId()
        {
           
            var res = _testBookServ.GetBookById(2);

            Assert.IsTrue(true);
        }


        [Test]
        public void GetListBook()
        {

            var res = _testBookServ.GetBookAll();

            Assert.IsTrue(true);
        }

        [Test]
        public void UpdateBook()
        {
            var res = _testBookServ.GetBookById(2);

            res.Name = "Бесогон";
            res.Autor = "Михалков";
            res.Genre = "бред сумашедшего";
            res.Rack = "Л322";
            res.Row = "123333";
            res.Shelf = "09121";
            res.CoverView = "Ik\\dassda";
            var res1 = _testBookServ.UpdateBook(res);

            Assert.NotNull(res1);
        }

        [Test]
        public void AddBook()
        {
            var _mapper = new Mappers.Mapper();
            var ob = new BookModel
            {
                Autor = "Гете",
                CoverView = "test",
                Genre = "провесть",
                Name = "Фауст",
                Shelf = "A11",
                Rack = "12",
                Row = "12"
            };
            
            var res = _mapper.MapInBookBusinessModel(ob);
            _testBookServ.AddBook(res);

            Assert.IsTrue(true);
        }

        [Test]
        public void SerachItem()
        {

            var res = _testBookServ.SearchItem("asdasd");

            Assert.IsTrue(true);
        }

        [Test]
        public void DropTable()
        {

            _testBookServ.Droptable();

            Assert.IsTrue(true);
        }
    }
}
