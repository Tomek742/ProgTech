using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataStorage
    {
        public List<IReader> readers = new List<IReader>();
        public List<IBook> books = new List<IBook>();
        public List<Content> contents = new List<Content>();
        public List<Event> borrows = new List<Event>();
    }
}
