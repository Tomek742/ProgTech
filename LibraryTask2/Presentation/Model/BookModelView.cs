using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Presentation.Model
{
    public class BookModelView : IBook
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int BookID { get; set; }
        public bool IsAvailable { get; set; }

        public BookModelView(string name, string author, int bookID)
        {
            Name = name;
            Author = author;
            BookID = bookID;
            IsAvailable = true;
        }
    }
}
