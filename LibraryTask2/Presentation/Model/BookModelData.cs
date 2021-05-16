using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;
using Presentation.API;

namespace Presentation.Model
{
    public class BookModelData : IBookModelData
    {
        public IBookService Service { get; }
        public BookModelData(IBookService service)
        {
            Service = service;
        }

        public IEnumerable<IBook> Book
        {
            get
            {
                IEnumerable<IBook> books = Service.GetBooks();
                return books;
            }
        }

        public IBook CreateBook(string Title, string Author, int ID)
        {
            return new BookModelView(Title, Author, ID);
        }
    }
}
