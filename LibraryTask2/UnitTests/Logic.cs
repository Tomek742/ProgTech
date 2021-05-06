using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;
using Data;

namespace UnitTests
{
    [TestClass]
    public class Logic
    {
        private IDataStorage storage;
        private LibraryManager libManager;
        private ILibraryManager ILibManager;

        [TestInitialize]
        public void Initialize()
        {
            storage = new DataStorage();
            libManager = new LibraryManager(new DataManager(storage));
            ILibManager = libManager;
        }

        [TestMethod]
        public void AddBookTest()
        {
            ILibManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            Assert.AreEqual(libManager.manager.GetBookID(1).BookID, 1);
        }

        [TestMethod]
        public void RemoveBookTest()
        {
            ILibManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            ILibManager.RemoveBook(1);
            Assert.IsNull(libManager.manager.GetBookID(1));
        }

        [TestMethod]
        public void AddReaderTest()
        {
            ILibManager.AddReader(new Reader("Tadeusz", 1));
            Assert.AreEqual(libManager.manager.GetReader(1).ReaderID, 1);
        }

        [TestMethod]
        public void RemoveReaderTest()
        {
            ILibManager.AddReader(new Reader("Tadeusz", 1));
            ILibManager.RemoveReader(1);
            Assert.IsNull(libManager.manager.GetReader(1));
        }

        [TestMethod]
        public void SetQuantityTest()
        {
            ILibManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            libManager.SetQuantity(1, 5);
            Assert.AreEqual(libManager.manager.GetQuantity(1), 5);
        }

        [TestMethod]
        public void ChangeQuantityTest()
        {
            ILibManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            libManager.SetQuantity(1, 5);
            ILibManager.ChangeQuantity(1, 1);
            Assert.AreEqual(libManager.manager.GetQuantity(1), 6);
        }

        [TestMethod]
        public void AddBorrowTest()
        {
            ILibManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            ILibManager.AddReader(new Reader("Tadeusz", 1));
            ILibManager.SetQuantity(1, 2);
            ILibManager.BorrowBook(1, 1, 1);
            Assert.AreEqual(libManager.manager.GetBorrowID(1), 1);
            Assert.AreEqual(libManager.manager.GetQuantity(1), 1);
        }

        [TestMethod]
        public void RemoveBorrowTest()
        {
            ILibManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            ILibManager.AddReader(new Reader("Tadeusz", 1));
            ILibManager.SetQuantity(1, 2);
            ILibManager.BorrowBook(1, 1, 1);
            ILibManager.RemoveBorrow(1);
            Assert.IsNull(libManager.manager.GetBorrow(1));
        }

        [TestMethod]
        public void LibraryManagerConstructor()
        {
            LibraryManager library = new LibraryManager(null);
            Assert.AreEqual(library.manager, null);
        }
    }
}
