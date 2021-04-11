using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataManager : IDataManager
    {
        private DataStorage storage;

        public DataManager(DataStorage storage)
        {
            this.storage = storage;
        }

        public void AddBook(Book book)
        {
            if (book != null)
                storage.books.Add(book);
        }
        public void RemoveBook(int ID)
        {
            Book temp = GetBookID(ID);
            if (temp != null)
            {
                storage.books.Remove(temp);
            }
        }
        public Book GetBookID(int ID)
        {
            return storage.books.Find(x => x.BookID == ID);
        }
        public Book GetBook(string name)
        {
            return storage.books.Find(x => x.Name == name);
        }
        public bool CheckIfBookIsAvaliable(int ID)
        {
            Book temp = GetBookID(ID);
            if (temp == null)
                return false;
            else
                return temp.IsAvailable;
        }

        //Readers
        public void AddReader(Reader reader)
        {
            if (reader != null)
                storage.readers.Add(reader);
        }

        public Reader GetReader(int ID)
        {
            return storage.readers.Find(x => x.ReaderID == ID);
        }

        public int GetReaderID(string name)
        {
            return storage.readers.Find(x => x.Name == name).ReaderID;
        }

        public void RemoveReader(int ID)
        {
            Reader temp = GetReader(ID);
            if (temp != null)
            {
                storage.readers.Remove(temp);
            }
        }

        //Content
        public void SetQuantity(int ID, int quantity)
        {
            Book temp = GetBookID(ID);
            storage.contents.Add(new Content(temp, quantity));
        }

        public void ChangeQuantity(int ID, int newQuantity)
        {
            Content temp = storage.contents.Find(x => x.BookItem.BookID == ID);
            if (newQuantity < 0 && temp.Quantity >= 0)
            {
                temp.Quantity += newQuantity;
                if (GetQuantity(ID) == 0) temp.BookItem.IsAvailable = false;
            }
            if (newQuantity > 0)
            {
                temp.Quantity += newQuantity;
                if (GetQuantity(ID) == 0) temp.BookItem.IsAvailable = false;
            }
        }
        public int GetQuantity(int ID)
        {
            return storage.contents.Find(x => x.BookItem.BookID == ID).Quantity;
        }

        //Borrows
        public void BorrowBook(int bookID, int readerID, int ID)
        {
            Book tempBook = GetBookID(bookID);
            Reader tempReader = GetReader(readerID);
            if (tempBook != null || tempReader != null)
            {
                storage.borrows.Add(new Event(tempBook, tempReader, DateTime.Now.Date, ID));
                ChangeQuantity(bookID, -1);
                if (GetQuantity(bookID) == 0) tempBook.IsAvailable = false;
            }
        }

        public void RemoveBorrow(int ID)
        {
            Event temp = storage.borrows.Find(x => x.EventID == ID);
            if (temp != null)
            {
                storage.borrows.Remove(temp);
                ChangeQuantity(temp.BookItem.BookID, 1);
                if (GetQuantity(temp.BookItem.BookID) != 0) temp.BookItem.IsAvailable = true;
            }
        }

        public Event GetBorrow(int ID)
        {
            return storage.borrows.Find(x => x.EventID == ID);
        }
    }
}
