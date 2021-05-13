using System.Collections.Generic;

namespace Data
{
    public abstract class IDataStorage
    {
        public List<IReader> readers = new List<IReader>();
        public List<IBook> books = new List<IBook>();
        public List<IContent> contents = new List<IContent>();
        public List<IEvent> borrows = new List<IEvent>();
    }
}
