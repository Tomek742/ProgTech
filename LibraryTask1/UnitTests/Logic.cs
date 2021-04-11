using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic;
using Data;

namespace UnitTests
{
    [TestClass]
    public class Logic
    {
        private DataStorage storage;
        private LibraryManager libManager;

        [TestInitialize]
        public void Initialize()
        {
            storage = new DataStorage();
            libManager = new LibraryManager(new DataManager(storage));
        }

        [TestMethod]
        public void AddBookTest()
        {
            libManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            Assert.AreEqual(libManager.manager.GetBookID(1).BookID, 1);
        }

        [TestMethod]
        public void RemoveBookTest()
        {
            libManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            libManager.RemoveBook(1);
            Assert.IsNull(libManager.manager.GetBookID(1));
        }

        [TestMethod]
        public void AddReaderTest()
        {
            libManager.AddReader(new Reader("Tadeusz", 1));
            Assert.AreEqual(libManager.manager.GetReader(1).ReaderID, 1);
        }

        [TestMethod]
        public void RemoveReaderTest()
        {
            libManager.AddReader(new Reader("Tadeusz", 1));
            libManager.RemoveReader(1);
            Assert.IsNull(libManager.manager.GetReader(1));
        }

        [TestMethod]
        public void SetQuantityTest()
        {
            libManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            libManager.SetQuantity(1, 5);
            Assert.AreEqual(libManager.manager.GetQuantity(1), 5);
        }

        [TestMethod]
        public void ChangeQuantityTest()
        {
            libManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            libManager.SetQuantity(1, 5);
            libManager.ChangeQuantity(1, 1);
            Assert.AreEqual(libManager.manager.GetQuantity(1), 6);
        }

        [TestMethod]
        public void AddBorrowTest()
        {
            libManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            libManager.AddReader(new Reader("Tadeusz", 1));
            libManager.SetQuantity(1, 2);
            libManager.BorrowBook(1, 1, 1);
            Assert.AreEqual(libManager.manager.GetBorrowID(1), 1);
            Assert.AreEqual(libManager.manager.GetQuantity(1), 1);
        }

        [TestMethod]
        public void RemoveBorrowTest()
        {
            libManager.AddBook(new Book("Pan Tadeusz", "Adam Mickiewicz", 1));
            libManager.AddReader(new Reader("Tadeusz", 1));
            libManager.SetQuantity(1, 2);
            libManager.BorrowBook(1, 1, 1);
            libManager.RemoveBorrow(1);
            Assert.IsNull(libManager.manager.GetBorrow(1));
        }
    }
}
