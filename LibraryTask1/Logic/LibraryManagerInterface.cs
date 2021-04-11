using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Logic
{
    public interface LibraryManagerInterface
    {
        void AddBook(Book book);
        void DestroyBook(Book book);
        int GetBookID(string name);
        Book GetBook(string name);
        bool CheckIfBookIsAvaliable(Book book);

        void AddReader(Reader reader);
        Reader GetReader(int ID);
        int GetReaderID(string name);
        void RemoveReader(Reader reader);

        void SetQuantity(Book book, int quantity);
        void ChangeQuantity(Book book, int newQuantity);
        int GetQuantity(Book book);

        void BorrowBook(Book book, Reader reader, int ID);
        void RemoveBorrow(int ID);
        Event GetBorrow(int ID);
    }
}
