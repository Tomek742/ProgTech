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
        private Book tbook = null;
        private Content List = Content();
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
        public int GetBookID(Book book)
        {
            return book.BookID.get();
        }
        public Book GetBook(string Name)
        {
            try
            {
                return List.BookList[Name];
            }
            catch(KeynotFoundException)
            {
                return null;
            }
            //Content.
            //Finding Book based of name in Content
        }

        public void AddBorrowEvent(Reader user, string Name){
            if (user == null || Name == null)
                throw new ArgumentNullException();
            if (CheckIfBookIsAvaliable(Name))  //checking if any in the library
                throw new Exception("No book avaliable!");
            else
                Event tmp = new Event(GetBook(Name), user, DateTime.Now.Date); // to do add to some sort of registry?
        }
        public bool CheckIfBookIsAvaliable(string Name)
        {
            tbook = GetBook(Name);
            return tbook.IsAvailable;
        }
    }
}