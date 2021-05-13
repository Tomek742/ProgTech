using System.Collections.Generic;

namespace Data
{
    public class DataStorage : IDataStorage
    {
        public new List<IReader> readers = new List<IReader>();
        public new List<IBook> books = new List<IBook>();
        public new List<IContent> contents = new List<IContent>();
        public new List<IEvent> borrows = new List<IEvent>();
    }
}
