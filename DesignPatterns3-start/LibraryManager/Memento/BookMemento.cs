using LibraryManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Memento
{
    public class BookMemento
    {
        public Book Book { get; set; }
        public List<BookLogItem> LogItems { get; set; }
        public string ISBN { get; set; }
    }

}
