using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IDataManager
    {
        void AddBook(IBook book);
        void RemoveBook(int ID);
        IBook GetBookID(int ID);
        IBook GetBook(string name);
        bool CheckIfBookIsAvaliable(int ID);

        void AddReader(IReader reader);
        IReader GetReader(int ID);
        int GetReaderID(string name);
        void RemoveReader(int ID);

        void SetQuantity(int ID, int quantity);
        void ChangeQuantity(int ID, int newQuantity);
        int GetQuantity(int ID);

        void BorrowBook(int bookID, int readerID, int ID);
        void RemoveBorrow(int ID);
        Event GetBorrow(int ID);
        int GetBorrowID(int ID);
    }
}
