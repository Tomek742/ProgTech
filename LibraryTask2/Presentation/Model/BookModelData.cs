using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.DataFiles;
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

        public IEnumerable<IBookData> Book
        {
            get
            {
                IEnumerable<IBookData> books = Service.GetBooks();
                return books;
            }
        }

        public IBookModelView CreateBook(string Title, string Author, int ID)
        {
            return new BookModelView(Title, Author, ID);
        }
    }
}
