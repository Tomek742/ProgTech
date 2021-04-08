using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryTask1.DataLayer;

namespace LibraryTask1.LogicLayer
{
    class LibraryManager
    {
        public void AddBook(Book book)
        {
            if (book != null)
                Content.Add(book);
            else
                throw new ArgumentNullException();
        }
        public void DestroyBook(Book book)
        {
            if (book != null)
                Content.Remove(book);
            else
                throw new ArgumentNullException();
        }
        public void BorrowBook(Book book)
        {
            if (book != null)
                book.IsAvailable.set(false);
            else
                throw new ArgumentNullException();
        }

    }
}
