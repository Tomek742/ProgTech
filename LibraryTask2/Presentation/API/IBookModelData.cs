using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using Service.API;

namespace Presentation.API
{
    interface IBookModelData
    {
        IBookService Service { get; }
        IEnumerable<IBook> Book { get; }
        IBook CreateBook(string Title, string Author, int ID);
    }
}
