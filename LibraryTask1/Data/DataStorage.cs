using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DataStorage
    {
        public List<Reader> readers = new List<Reader>();
        public List<Book> books = new List<Book>();
        public List<Content> contents = new List<Content>();
        public List<Event> borrows = new List<Event>();
    }
}
