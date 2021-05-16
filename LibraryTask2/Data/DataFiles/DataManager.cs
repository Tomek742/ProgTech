using System;
using System.Collections.Generic;
using System.Linq;
using Data.API;

namespace Data.DataFiles
{
    public class DataManager : IDataManager
    {

        public IReader Transform(Readers Reader)
        {
            return new Reader(Reader.name, Reader.id);
        }
        public IBook Transform(Books Book)
        {
            return new Book(Book.title, Book.author, Book.id);
        }

        public IEvent Transform(Events Event)
        {
            return new Event(Event.id, Event.date, Event.book_id, Event.reader_id);
        }
        public IEnumerable<IReader> GetReaders()
        {
            using (var context = new LibraryDataContext())
            {
                List<IReader> list = new List<IReader>();
                context.Readers.ToList();
                foreach (Readers Reader in context.Readers.ToList())
                {
                    list.Add(Transform(Reader));
                }
                return list;
            }
        }

        public IReader GetReader(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Readers Reader in context.Readers.ToList())
                {
                    if (Reader.id.Equals(ID))
                    {
                        return Transform(Reader);
                    }
                }
                return null;
            }
        }

        public bool AddReader(int ID, string Name)
        {
            using (var context = new LibraryDataContext())
            {
                if (GetReader(ID) == null && !Name.Equals(null))
                {
                    Readers NewReader = new Readers
                    {
                        name = Name,
                        id = ID
                    };
                    context.Readers.InsertOnSubmit(NewReader);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateReader(int ID, string Name)
        {
            using (var context = new LibraryDataContext())
            {
                Readers Reader = context.Readers.SingleOrDefault(i => i.id == ID);
                if (GetReader(ID) != null && !Name.Equals(null))
                {
                    Reader.name = Name;
                    Reader.id = ID;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteReader(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                Readers Reader = context.Readers.SingleOrDefault(i => i.id == ID);
                if (GetReader(ID) != null && !ID.Equals(null))
                {
                    context.Readers.DeleteOnSubmit(Reader);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        public IEnumerable<IBook> GetBooks()
        {
            using (var context = new LibraryDataContext())
            {
                List<IBook> list = new List<IBook>();
                context.Books.ToList();
                foreach (Books Book in context.Books.ToList())
                {
                    list.Add(Transform(Book));
                }
                return list;
            }
        }

        public IBook GetBookByID(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Books Book in context.Books.ToList())
                {
                    if (Book.id.Equals(ID))
                    {
                        return Transform(Book);
                    }
                }
                return null;
            }
        }

        public IEnumerable<IBook> GetBookByName(string Name)
        {
            using (var context = new LibraryDataContext())
            {
                List<IBook> list = new List<IBook>();
                context.Books.ToList();
                foreach (Books Book in context.Books.ToList())
                {
                    if (Book.title.Equals(Name))
                    {
                        list.Add(Transform(Book));
                        return list;
                    }
                }
                return null;
            }
        }

        public IBook GetBookByAuthor(string Author)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Books Book in context.Books.ToList())
                {
                    if (Book.author.Equals(Author))
                    {
                        return Transform(Book);
                    }
                }
                return null;
            }
        }
        public bool AddBook(int ID, string Name, string Author)
        {
            using (var context = new LibraryDataContext())
            {
                if (GetBookByName(Name) == null && !Name.Equals(null) && !ID.Equals(null) && !Author.Equals(null))
                {
                    Books NewBook = new Books
                    {
                        id = ID,
                        title = Name,
                        author = Author,
                        isAvailable = true,
                    };
                    context.Books.InsertOnSubmit(NewBook);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateBook(int ID, string Name, string Author)
        {
            using (var context = new LibraryDataContext())
            {
                Books Book = context.Books.SingleOrDefault(i => i.id == ID);
                if (!ID.Equals(null) && !Name.Equals(null) && !Author.Equals(null))
                {
                    Book.id = ID;
                    Book.title = Name;
                    Book.author = Author;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public void ReturnBook(int? ID)
        {
            using (var context = new LibraryDataContext())
            {
                Books Book = context.Books.SingleOrDefault(i => i.id == ID);
                if (GetBookByID(ID.GetValueOrDefault()) != null && !ID.Equals(null))
                {
                    Book.isAvailable = true;
                    context.SubmitChanges();
                }
            }
        }

        public bool DeleteBook(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                Books Book = context.Books.SingleOrDefault(i => i.id == ID);
                if (GetBookByID(ID) != null && !ID.Equals(null))
                {

                    context.Books.DeleteOnSubmit(Book);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public IEnumerable<IEvent> GetEvents()
        {
            using (var context = new LibraryDataContext())
            {
                List<IEvent> list = new List<IEvent>();
                context.Events.ToList();
                foreach (Events Event in context.Events.ToList())
                {
                    list.Add(Transform(Event));
                }
                return list;
            }
        }

        public IEvent GetEventByID(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Events Event in context.Events.ToList())
                {
                    if (Event.id.Equals(ID))
                    {
                        return Transform(Event);
                    }
                }
                return null;
            }
        }

        public IEnumerable<IEvent> GetEventsByReaderID(int ReaderID)
        {
            using (var context = new LibraryDataContext())
            {
                List<IEvent> list = new List<IEvent>();
                foreach (Events Event in context.Events.ToList())
                {
                    if (Event.reader_id.Equals(ReaderID))
                    {
                        list.Add(Transform(Event));
                    }
                }
                return list;
            }
        }

        public bool AddEvent(int EventID, DateTime Date, int BookID, int ReaderID)
        {
            using (var context = new LibraryDataContext())
            {
                if (!EventID.Equals(null) && !Date.Equals(null) && !BookID.Equals(null) && !ReaderID.Equals(null))
                {
                    Books Book = context.Books.SingleOrDefault(i => i.id == BookID);
                    Readers Reader = context.Readers.SingleOrDefault(i => i.id == ReaderID);
                    Book.isAvailable = false;

                    Events NewEvent = new Events
                    {
                        id = EventID,
                        date = Date,
                        book_id = BookID,
                        reader_id = ReaderID,
                    };
                    context.Events.InsertOnSubmit(NewEvent);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool UpdateEventBook(int ID, int BookID)
        {
            using (var context = new LibraryDataContext())
            {
                Events Event = context.Events.SingleOrDefault(i => i.id == ID);
                if (!BookID.Equals(null))
                {
                    ReturnBook(Event.book_id);
                    Event.book_id = BookID;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
        public bool UpdateEventReader(int ID, int ReaderID)
        {
            using (var context = new LibraryDataContext())
            {
                Events Event = context.Events.SingleOrDefault(i => i.id == ID);
                if (!ReaderID.Equals(null))
                {
                    Event.reader_id = ReaderID;
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteEvent(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                Events Event = context.Events.SingleOrDefault(i => i.id == ID);
                if (GetEventByID(ID) != null && !ID.Equals(null))
                {
                    ReturnBook(Event.book_id);
                    context.Events.DeleteOnSubmit(Event);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
