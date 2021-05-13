using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Service.API;

namespace Service.DataFiles
{
    class BookService : IBookService
    {
        public IEnumerable<Book> GetBooks()
        {
            using (var context = new LibraryDataContext())
            {
                return context.Books.ToList();
            }
        }

        public Book GetBook(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Book Book in context.Books.ToList())
                {
                    if (Book.id.Equals(ID))
                    {
                        return Book;
                    }
                }
                return null;
            }
        }

        public bool AddBook(int ID, string Title, string Author)
        {
            using (var context = new LibraryDataContext())
            {
                if (GetBook(ID) == null && !Title.Equals(null) && !Author.Equals(null))
                {
                    Book NewBook = new Book
                    {
                        id = ID,
                        title = Title,
                        author = Author,
                        isAvailable = true
                    };
                    context.Books.InsertOnSubmit(NewBook);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateBook(int ID, string Title, string Author)
        {
            using (var context = new LibraryDataContext())
            {
                Book Book = context.Books.SingleOrDefault(i => i.id == ID);
                if (GetBook(ID) == null && !Title.Equals(null) && !Author.Equals(null))
                {
                    Book.id = ID;
                    Book.title = Title;
                    Book.author = Author;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteBook(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                Book Book = context.Books.SingleOrDefault(i => i.id == ID);
                if (GetBook(ID) != null)
                {
                    context.Books.DeleteOnSubmit(Book);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}