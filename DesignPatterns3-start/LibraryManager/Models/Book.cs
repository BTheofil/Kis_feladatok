using System;
using LibraryManager.Persistence;

namespace LibraryManager.Models
{

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastModificationDate { get; set; }

        public Book()
        {
            
        }

        public Book(BookData info)
        {
            Title = info.Title;
            Author = info.Author;
            LastModificationDate = info.LastModificationDate;
        }

        public Book Clone()
        {
            return new Book()
            {
                Title = this.Title,
                Author = this.Author,
                LastModificationDate = this.LastModificationDate
            };
        }

    }


}
