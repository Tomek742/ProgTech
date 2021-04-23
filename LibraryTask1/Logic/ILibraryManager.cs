using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public interface ILibraryManager
    {
        void AddBook(IBook book);
        void AddReader(IReader reader);
        void SetQuantity(int ID, int quantity);
        void GetQuantity(int ID);
        void BorrowBook(int bookID, int readerID, int ID);
        void RemoveBook(int ID);
        void RemoveReader(int ID);
        void RemoveBorrow(int ID);
        void ChangeQuantity(int ID, int newValue);
    }
}
