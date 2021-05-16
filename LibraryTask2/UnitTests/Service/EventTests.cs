using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Data.API;
using Data.DataFiles;
using Service.API;
using Service.DataFiles;

namespace UnitTests.Service
{
    [TestClass]
    public class EventTests
    {
        public IDataManager manager;
        public IReaderService readerService;
        public IBookService bookService;
        public IEventService eventService;

        [TestInitialize]
        public void Initialize()
        {
            manager = new DataManager();
            readerService = new ReaderService();
            bookService = new BookService();
            eventService = new EventService();
        }

        [TestMethod]
        public void AddEventToDatabaseTest()
        {
            Assert.IsTrue(readerService.AddReader(1, "Marek Towarek"));
            Assert.IsTrue(bookService.AddBook(1, "Zaczarowana zagroda", "Czesław Centkiewicz"));

            Assert.IsTrue(eventService.AddEvent(1, DateTime.Now, bookService.GetBookByID(1).BookID, readerService.GetReader(1).ReaderID));

            Assert.IsTrue(eventService.DeleteEvent(eventService.GetEventByID(1).EventID));
            Assert.IsTrue(bookService.DeleteBook(bookService.GetBookByID(1).BookID));
            Assert.IsTrue(readerService.DeleteReader(readerService.GetReader(1).ReaderID));
        }

        [TestMethod]
        public void UpdateEvent()
        {
            Assert.IsTrue(readerService.AddReader(1, "Piotr Skowyrski"));
            Assert.IsTrue(readerService.AddReader(2, "Jarosław Jarzabkowski"));
            Assert.IsTrue(bookService.AddBook(1, "Dzieci z Bullerbyn", "Astrid Lindgren"));
            Assert.IsTrue(bookService.AddBook(2, "Doktor Dolittle i jego zwierzęta", "Hugh Lofting"));

            Assert.IsTrue(bookService.GetBookByID(1).IsAvailable);

            Assert.IsTrue(eventService.AddEvent(1, DateTime.Now, bookService.GetBookByID(1).BookID, readerService.GetReader(1).ReaderID));

            //Assert.IsFalse(bookService.GetBookByID(1).IsAvailable);

            Assert.IsTrue(eventService.UpdateEventBook(eventService.GetEventByID(1).EventID, 2));
            Assert.IsTrue(eventService.UpdateEventReader(eventService.GetEventByID(1).EventID, 2));

            Assert.IsTrue(bookService.GetBookByID(1).IsAvailable);

            Assert.IsTrue(eventService.DeleteEvent(manager.GetEventByID(1).EventID));
            Assert.IsTrue(bookService.DeleteBook(bookService.GetBookByID(1).BookID));
            Assert.IsTrue(bookService.DeleteBook(bookService.GetBookByID(2).BookID));
            Assert.IsTrue(readerService.DeleteReader(readerService.GetReader(1).ReaderID));
            Assert.IsTrue(readerService.DeleteReader(readerService.GetReader(2).ReaderID));
        }
    }
}
