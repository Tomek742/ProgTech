﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTask1.DataLayer
{
    class Event
    {
        public Book BookItem { get; set; }
        public Reader ReaderPerson { get; set; }
        public DateTime Date { get; set; }

        public Event(Book bookItem, Reader readerPerson, DateTime date)
        {
            BookItem = bookItem;
            ReaderPerson = readerPerson;
            Date = date;
        }
    }
}