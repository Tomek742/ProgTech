using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Service.API;

namespace Service.DataFiles
{
    class EventService : IEventService
    {
        public IEnumerable<Event> GetEvents()
        {
            using (var context = new LibraryDataContext())
            {
                return context.Events.ToList();
            }
        }

        public Event GetEventById(int ID)
        {
            using (var context = new LibraryDataContext())
            {
                foreach (Event Event in context.Events.ToList())
                {
                    if (Event.id.Equals(ID))
                    {
                        return Event;
                    }
                }
                return null;
            }
        }

        public bool AddEvent(DateTime date, int ID, int BookID, int ReaderID)
        {
            using (var context = new LibraryDataContext())
            {
                if (!date.Equals(null) && !ID.Equals(null) && !BookID.Equals(null) && !ReaderID.Equals(null))
                {
                    Book Book = context.Books.SingleOrDefault(i => i.id == BookID);
                    Reader Reader = context.Readers.SingleOrDefault(i => i.id == ReaderID);
                    if (Book.isAvailable == true)
                    {
                        Event NewEvent = new Event
                        {
                            date = date,
                            id = ID,
                            book_id = BookID,
                            reader_id = ReaderID,
                        };
                        context.Events.InsertOnSubmit(NewEvent);
                        context.SubmitChanges();
                        Book.isAvailable = false;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        public bool UpdateEvent(int ID, int ReaderID)
        {
            using (var context = new LibraryDataContext())
            {
                Event Event = context.Events.SingleOrDefault(i => i.id == ID);
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
                Event Event = context.Events.SingleOrDefault(i => i.id == ID);
                if (GetEventById(ID) != null && !ID.Equals(null))
                {
                    context.Events.DeleteOnSubmit(Event);
                    context.SubmitChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
