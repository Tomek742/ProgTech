using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data.DataFiles;
using Data.API;

namespace UnitTests.Data
{
    [TestClass]
    public class BookTests
    {
        public IDataManager manager;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
        }

        [TestMethod]
        public void AddBookToDatabaseTest()
        {
            Assert.IsTrue(manager.AddBook(1, "Asiunia", "Joanna Papuzinska"));
            Assert.AreEqual(manager.GetBookByID(1).Name, "Asiunia");
            Assert.AreEqual(manager.GetBookByID(1).Author, "Joanna Papuzinska");
            Assert.AreEqual(manager.GetBookByID(1).IsAvailable, true);

            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(1).BookID));
        }

        [TestMethod]
        public void AddSameBookToDatabaseTest()
        {
            Assert.IsTrue(manager.AddBook(1, "Detektyw Pozytywka", "Grzegorz Kasdepke"));
            Assert.IsFalse(manager.AddBook(1, "Detektyw Pozytywka", "Grzegorz Kasdepke"));

            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(1).BookID));
        }
    }
}
