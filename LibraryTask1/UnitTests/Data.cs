using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data;

namespace UnitTests
{
    [TestClass]
    public class Data
    {
        [TestMethod]
        public void BookConstructor()
        {
            Book book = new Book("Pan Tadeusz", "Adam Mickiewicz", 1);
            Assert.AreEqual(book.Name, "Pan Tadeusz");
            Assert.AreEqual(book.Author, "Adam Mickiewicz");
            Assert.AreEqual(book.BookID, 1);
            Assert.AreEqual(book.IsAvailable, true);
        }

        [TestMethod]
        public void ReaderConstructor()
        {
            Reader reader = new Reader("Adam", 1);
            Assert.AreEqual(reader.Name, "Adam");
            Assert.AreEqual(reader.ReaderID, 1);
        }

        [TestMethod]
        public void EventConstructor()
        {
            DateTime sss = DateTime.Now;
            Reader reader = new Reader("Adam", 1);
            Book book = new Book("Pan Tadeusz", "Adam Mickiewicz", 1);
            Event e = new Event(book, reader, sss, 1);
            Assert.AreEqual(e.BookItem, book);
            Assert.AreEqual(e.ReaderPerson, reader);
            Assert.AreEqual(e.Date, sss);
            Assert.AreEqual(e.EventID, 1);
        }

        [TestMethod]
        public void ContentConstructor()
        {
            Book book = new Book("Pan Tadeusz", "Adam Mickiewicz", 1);
            Content e = new Content(book, 1);
            Assert.AreEqual(e.BookItem, book);
            Assert.AreEqual(e.Quantity, 1);
        }
    }
}
