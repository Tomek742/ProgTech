using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Content : IContent
    {
        public IBook BookItem { get; set; }
        public int Quantity { get; set; }

        public Content(IBook bookItem, int quantity)
        {
            BookItem = bookItem;
            Quantity = quantity;
        }
    }
}
