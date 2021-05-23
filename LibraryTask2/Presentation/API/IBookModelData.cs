using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Service.DataFiles;

namespace Presentation.API
{
    interface IBookModelData
    {
        IBookService Service { get; }
        IEnumerable<IBookData> Book { get; }
        IBookModelView CreateBook(string Title, string Author, int ID);
    }
}
