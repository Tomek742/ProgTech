using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask1.DataLayer;

namespace LibraryTask1.LogicLayer
{
    public class LibraryManager : LibraryManagerInterface
    {
        private List<Reader> readers = new List<Reader>();
        private List<Book> books = new List<Book>();
        private List<Content> contents = new List<Content>();
        private List<Event> borrows = new List<Event>();

        //Books
        public void AddBook(Book book)
        {
            if (book != null)
                books.Add(book);
        }
        public void DestroyBook(Book book)
        {
            if (book != null)
                books.Remove(book);
        }
        public int GetBookID(string name)
        {
            return books.Find(x => x.Name == name ).BookID;
        }
        public Book GetBook(string name)
        {
            return books.Find(x => x.Name == name );
        }
        public bool CheckIfBookIsAvaliable(Book book)
        {
            if (book == null)
                return false;
            else
                return book.IsAvailable;
        }

        //Readers
        public void AddReader(Reader reader)
        {
            if (reader != null)
                readers.Add(reader);
        }

        public Reader GetReader(int ID)
        {
            return readers.Find(x => x.ReaderID == ID );
        }

        public int GetReaderID(string name)
        {
            return readers.Find(x => x.Name == name ).ReaderID;
        }

        public void RemoveReader ( Reader reader )
        {
            readers.Remove(reader);
        }

        //Content
        public void SetQuantity(Book book, int quantity)
        {
            contents.Add(new Content(book, quantity));
        }

        public void ChangeQuantity(Book book, int newQuantity)
        {
            Content temp = contents.Find(x => x.BookItem == book);
            if (newQuantity < 0 && temp.Quantity >= 0)
            {
                temp.Quantity += newQuantity;
                if (GetQuantity(book) == 0) book.IsAvailable = false;
            }
            if (newQuantity > 0)
            {
                temp.Quantity += newQuantity;
                if (GetQuantity(book) == 0) book.IsAvailable = false;
            }
        }
        public int GetQuantity(Book book)
        {
            return contents.Find(x => x.BookItem == book).Quantity;
        }

        //Borrows
        public void BorrowBook(Book book, Reader reader, int ID)
        {
            if (book != null || reader != null)
            {
                borrows.Add(new Event(book, reader, DateTime.Now.Date, ID));
                ChangeQuantity(book, -1);
                if (GetQuantity(book) == 0) book.IsAvailable = false;
            }
        }

        public void RemoveBorrow(int ID)
        {
            Event temp = borrows.Find(x => x.EventID == ID);
            if (temp != null)
            {
                borrows.Remove(temp);
                ChangeQuantity(temp.BookItem, 1);
                if (GetQuantity(temp.BookItem) != 0) temp.BookItem.IsAvailable = true;
            }
        }

        public Event GetBorrow(int ID)
        {
            return borrows.Find(x => x.EventID == ID);
        }
    }
}
