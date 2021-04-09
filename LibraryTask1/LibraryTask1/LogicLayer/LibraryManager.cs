using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask1.DataLayer;

namespace LibraryTask1.LogicLayer
{
    class LibraryManager
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
            else
                throw new ArgumentNullException();
        }
        public void DestroyBook(Book book)
        {
            if (book != null)
                books.Remove(book);
            else
                throw new ArgumentNullException();
        }
        public int GetBookID(string name)
        {
            try
            {
                return books.Find(x => x.Name == name ).BookID;
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }
        public Book GetBook(string name)
        {
            try
            {
                return books.Find(x => x.Name == name );
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
            //Content.
            //Finding Book based of name in Content
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
            else
                throw new ArgumentNullException();
        } //Do we want list of readers?

        public Reader GetReader(int ID)
        {
            try
            {
                return readers.Find(x => x.ReaderID == ID );
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public int GetReaderID(string name)
        {
            try
            {
                return readers.Find(x => x.Name == name ).ReaderID;
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
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
            }
            if (newQuantity > 0)
            {
                temp.Quantity += newQuantity;
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
            else
                throw new ArgumentNullException();
        }

        //public Event GetBorrow(int ID)
        //{
        //    return borrows.Find(x => x.EventID == ID );
        //}

        //    public void ReturnBook(Book book, Reader reader)
        //    {
        //        borrows.Remove.
        //        //if (borrows.Find(x => x.BookItem.Equals(book))        }
        //}
    }
}
