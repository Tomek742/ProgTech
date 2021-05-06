using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IContent
    {
        IBook BookItem { get; set; }
        int Quantity { get; set; }
    }
}
