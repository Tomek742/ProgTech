using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int BookID { get; set; }
        public bool IsAvailable { get; set; }

        public Book(string name, string author, int bookID, bool isAvailable)
        {
            Name = name;
            Author = author;
            BookID = bookID;
            IsAvailable = isAvailable;
        }
    }
}
