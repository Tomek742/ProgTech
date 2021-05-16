using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataFiles;
using Data.API;
using Service.API;
using Data;

namespace Service.DataFiles
{
    public class BookService : IBookService
    {
        private IDataManager manager;
        public BookService(IDataManager manager)
        {
            this.manager = manager;
        }
        public BookService()
        {
            this.manager = new DataManager();
        }
        public IEnumerable<IBook> GetBooks()
        {
            return manager.GetBooks();
        }

        public IBook GetBookByID(int ID)
        {
            return manager.GetBookByID(ID);
        }

        public IEnumerable<IBook> GetBooksByAuthor(string Author)
        {
            return manager.GetBooksByAuthor(Author);
        }

        public IBook GetBookByName(string Name)
        {
            return manager.GetBookByName(Name);
        }
        public bool AddBook(int ID, string Name, string Author)
        {
            return manager.AddBook(ID, Name, Author);
        }

        public bool UpdateBook(int ID, string Name, string Author)
        {
            return manager.UpdateBook(ID, Name, Author);
        }

        public bool DeleteBook(int ID)
        {
            return manager.DeleteBook(ID);
        }
    }
}