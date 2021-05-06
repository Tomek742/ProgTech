using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataManager : DataManagerBase
    {
        public IDataStorage storage;

        public DataManager(IDataStorage storage)
        {
            this.storage = storage;
        }

        public override void AddBook(IBook book)
        {
            if (book != null)
                storage.books.Add(book);
        }
        public override void RemoveBook(int ID)
        {
            IBook temp = GetBookID(ID);
            if (temp != null)
            {
                storage.books.Remove(temp);
            }
        }
        public override IBook GetBookID(int ID)
        {
            return storage.books.Find(x => x.BookID == ID);
        }
        public override IBook GetBook(string name)
        {
            return storage.books.Find(x => x.Name == name);
        }
        public override bool CheckIfBookIsAvaliable(int ID)
        {
            IBook temp = GetBookID(ID);
            if (temp == null)
                return false;
            else
                return temp.IsAvailable;
        }

        //Readers
        public override void AddReader(IReader reader)
        {
            if (reader != null)
                storage.readers.Add(reader);
        }

        public override IReader GetReader(int ID)
        {
            return storage.readers.Find(x => x.ReaderID == ID);
        }

        public override int GetReaderID(string name)
        {
            return storage.readers.Find(x => x.Name == name).ReaderID;
        }

        public override void RemoveReader(int ID)
        {
            IReader temp = GetReader(ID);
            if (temp != null)
            {
                storage.readers.Remove(temp);
            }
        }

        //Content
        public override void SetQuantity(int ID, int quantity)
        {
            IBook temp = GetBookID(ID);
            storage.contents.Add(new Content(temp, quantity));
        }

        public override void ChangeQuantity(int ID, int newQuantity)
        {
            IContent temp = storage.contents.Find(x => x.BookItem.BookID == ID);
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
        public override int GetQuantity(int ID)
        {
            return storage.contents.Find(x => x.BookItem.BookID == ID).Quantity;
        }

        //Borrows
        public override void BorrowBook(int bookID, int readerID, int ID)
        {
            IBook tempBook = GetBookID(bookID);
            IReader tempReader = GetReader(readerID);
            if (tempBook != null || tempReader != null)
            {
                storage.borrows.Add(new Event(tempBook, tempReader, DateTime.Now.Date, ID));
                ChangeQuantity(bookID, -1);
                if (GetQuantity(bookID) == 0) tempBook.IsAvailable = false;
            }
        }

        public override void RemoveBorrow(int ID)
        {
            IEvent temp = GetBorrow(ID);
            IBook tempBook = GetBookID(ID);
            if (temp != null)
            {
                storage.borrows.Remove(temp);
                ChangeQuantity(tempBook.BookID, 1);
                if (GetQuantity(temp.BookItem.BookID) != 0) temp.BookItem.IsAvailable = true;
            }
        }

        public override IEvent GetBorrow(int ID)
        {
            return storage.borrows.Find(x => x.EventID == ID);
        }

        public override int GetBorrowID(int ID)
        {
            return storage.borrows.Find(x => x.EventID == ID).EventID;
        }
    }
}
