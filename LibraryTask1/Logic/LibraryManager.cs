using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public class LibraryManager
    {
        public IDataManager manager;

        public LibraryManager(IDataManager manager)
        {
            this.manager = manager;
        }

        //Adding,setting
        public void AddBook (Book book)
        {
            manager.AddBook(book);
        }

        public void AddReader (Reader reader)
        {
            manager.AddReader(reader);
        }

        public void SetQuantity (int ID, int quantity)
        {
            manager.SetQuantity(ID, quantity);
        }

        public void BorrowBook (int bookID, int readerID, int ID)
        {
            manager.BorrowBook(bookID, readerID, ID);
        }

        //Removing
        public void RemoveBook (int ID)
        {
            manager.RemoveBook(ID);
        }

        public void RemoveReader (int ID)
        {
            manager.RemoveReader(ID);
        }

        public void RemoveBorrow (int ID)
        {
            manager.RemoveBorrow(ID);
        }

        //Changing
        public void ChangeQuantity(int ID, int newValue)
        {
            manager.ChangeQuantity(ID,newValue);
        }
    }
}
