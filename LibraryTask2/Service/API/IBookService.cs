using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Service.API
{
    public interface IBookService
    {
        IEnumerable<IBook> GetBooks();
        IBook GetBookByID(int ID);
        IEnumerable<IBook> GetBookByName(string Name);
        IBook GetBookByAuthor(string Author);
        bool AddBook(int ID, string Name, string Author);
        bool UpdateBook(int ID, string Name, string Author);
        bool DeleteBook(int ID);
    }
}
