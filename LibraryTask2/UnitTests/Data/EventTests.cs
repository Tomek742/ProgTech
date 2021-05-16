using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data.API;
using Data.DataFiles;

namespace UnitTests.Data
{
    [TestClass]
    public class EventTests
    {
        public IDataManager manager;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
        }

        [TestMethod]
        public void AddEventToDatabaseTest()
        {
            Assert.IsTrue(manager.AddReader(1, "Marcin Dubiel"));
            Assert.IsTrue(manager.AddBook(1, "Afryka Kazika", "Łukasz Wierzbicki"));

            Assert.IsTrue(manager.AddEvent(1, DateTime.Now, manager.GetBookByID(1).BookID, manager.GetReader(1).ReaderID));

            Assert.IsTrue(manager.DeleteEvent(manager.GetEventByID(1).EventID));
            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(1).BookID));
            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void UpdateEvent()
        {
            Assert.IsTrue(manager.AddReader(1, "Piotr Pajak"));
            Assert.IsTrue(manager.AddReader(2, "Piotr Piwko"));
            Assert.IsTrue(manager.AddBook(1, "Cukierku, ty łobuzie!", "Waldemar Cichoń"));
            Assert.IsTrue(manager.AddBook(2, "Wesele", "Stanisław Wyspiański"));

            Assert.IsTrue(manager.GetBookByID(1).IsAvailable);

            Assert.IsTrue(manager.AddEvent(1, DateTime.Now, manager.GetBookByID(1).BookID, manager.GetReader(1).ReaderID));

            Assert.IsTrue(manager.UpdateEventBook(manager.GetEventByID(1).EventID, 2));
            Assert.IsTrue(manager.UpdateEventReader(manager.GetEventByID(1).EventID, 2));

            //Assert.IsFalse(manager.GetBookByID(1).IsAvailable);

            Assert.IsTrue(manager.DeleteEvent(manager.GetEventByID(1).EventID));
            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(1).BookID));
            Assert.IsTrue(manager.DeleteBook(manager.GetBookByID(2).BookID));
            Assert.IsTrue(manager.DeleteReader(manager.GetReader(1).ReaderID));
            Assert.IsTrue(manager.DeleteReader(manager.GetReader(2).ReaderID));
        }
    }
}
