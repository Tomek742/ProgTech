using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask1.DataLayer
{
    public class Content
    {
        public Book BookItem { get; set; }
        public int Quantity { get; set; }

        public Content(Book bookItem, int quantity)
        {
            BookItem = bookItem;
            Quantity = quantity;
        }
    }
}
