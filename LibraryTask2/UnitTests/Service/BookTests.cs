using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Service.API;
using System.Linq;
using Service.DataFiles;
using Data.API;
using Data.DataFiles;

namespace UnitTests.Service
{
    [TestClass]
    public class BookTests
    {
        public IDataManager manager;
        public BookService service;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
            service = new BookService(manager);
        }
        [TestMethod]
        public void AddBookToDatabaseTest()
        {
            Assert.IsTrue(service.AddBook(1, "Kapelusz Pani Wrony", "Danuta Parlak"));
            Assert.AreEqual(service.GetBookByID(1).Name, "Kapelusz Pani Wrony");
            Assert.AreEqual(service.GetBookByID(1).BookID, 1);
            Assert.AreEqual(service.GetBookByID(1).Author, "Danuta Parlak");
            Assert.AreEqual(service.GetBookByID(1).IsAvailable, true);

            Assert.IsTrue(service.DeleteBook(service.GetBookByID(1).BookID));
        }

        [TestMethod]
        public void AddSameBookToDatabaseTest()
        {
            Assert.IsTrue(service.AddBook(1, "Sposób na Elfa", "Marcin Pałasz"));
            Assert.IsFalse(service.AddBook(1, "Sposób na Elfa", "Marcin Pałasz"));

            Assert.IsTrue(service.DeleteBook(service.GetBookByID(1).BookID));
        }

        [TestMethod]
        public void GetBooksByName()
        {
            Assert.IsTrue(service.AddBook(1, "Baśnie 1", "Hans Christian Andersen"));
            Assert.IsTrue(service.AddBook(2, "Baśnie 2", "Hans Christian Andersen"));

            //Assert.IsTrue(service.GetBooksByAuthor("Hans Christian Andersen").Count() == 2);

            Assert.IsTrue(service.DeleteBook(service.GetBookByID(1).BookID));
            Assert.IsTrue(service.DeleteBook(service.GetBookByID(2).BookID));
        }
    }
}