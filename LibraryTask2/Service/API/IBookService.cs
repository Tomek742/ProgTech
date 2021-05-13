using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace Service.API
{
    interface IBookService
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int ID);
        bool AddBook(int ID, string Title, string Author);
        bool UpdateBook(int ID, string Title, string Author);
        bool DeleteBook(int ID);
    }
}
