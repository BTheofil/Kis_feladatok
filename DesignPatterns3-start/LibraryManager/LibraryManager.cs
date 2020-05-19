using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManager.FileManagement;
using LibraryManager.Memento;
using LibraryManager.Models;
using LibraryManager.Persistence;
using LibraryManager.Serializers;

namespace LibraryManager
{
    /// <summary>
    /// Könyvtár adatbázis
    /// </summary>
    public class LibraryManager
    {

        private Dictionary<string, Book> booksByISBNs = new Dictionary<string, Book>();
        private readonly Dictionary<string, List<BookLogItem>> logsByISBNs = new Dictionary<string, List<BookLogItem>>();

        /// <summary>
        /// Be van-e már regisztrálva az adott könyv az adatbázisba
        /// </summary>
        public bool IsISBNInLibrary(string isbn)
        {
            return booksByISBNs.ContainsKey(isbn);
        }

        /// <summary>
        /// Visszaadja a könyvtárban található könyvek adatait
        /// </summary>
        IEnumerable<BookData> GetBookDatas()
        {
            return booksByISBNs.Select(kvp => new BookData(kvp.Value, kvp.Key));
        }

        public IEnumerable<BookLogItemData> GetBookLogItemDatas()
        {
            var list = new List<BookLogItemData>();
            foreach (var isbn in logsByISBNs.Keys)
                foreach (var logItem in logsByISBNs[isbn])
                    list.Add(new BookLogItemData(logItem, isbn));
            return list;
        }

        private void Restore(List<BookData> books, List<BookLogItemData> logs)
        {
            booksByISBNs = books?.ToDictionary(b => b.ISBN, b => new Book(b)) ?? new Dictionary<string, Book>();
            logsByISBNs.Clear();
            foreach (var isbn in logs.Select(log => log.ISBN).Distinct())
            {
                logsByISBNs[isbn] =
                    logs.Where(log => log.ISBN == isbn).Select(log => new BookLogItem(log)).ToList();
            }
        }

        /// <summary>
        /// Könyvtár tartalmának kimentése
        /// </summary>
        public void Save(string path)
        {
            var fileManager = new FileManager();
            fileManager.StoreLibrary(new LibraryData
            {
                Books = GetBookDatas().ToList(),
                Logs = GetBookLogItemDatas().ToList()
            }, path);
        }

        /// <summary>
        /// Könyvtár betöltése fájlból
        /// </summary>
        public void Load(string path)
        {
            var exportManager = new FileManager();
            var libData = exportManager.LoadLibrary(path);
            if (libData != null)
                Restore(libData.Books, libData.Logs);
        }

        public void CreateNewBook(string newISBN)
        {
            booksByISBNs[newISBN] = new Book()
            {
                LastModificationDate = DateTime.Now,
            };
            Log(newISBN, $"new book (ISBN: {newISBN})");
        }

        private BookLogItem Log(string isbn, string message)
        {
            if (!logsByISBNs.ContainsKey(isbn))
                logsByISBNs[isbn] = new List<BookLogItem>();
            var log = new BookLogItem(DateTime.Now, message);

            logsByISBNs[isbn].Add(log);
            return log;

        }

        public void UpdateTitleOfBook(string isbn, string title)
        {
            booksByISBNs[isbn].Title = title;
            booksByISBNs[isbn].LastModificationDate = DateTime.Now;
            Log(isbn, $"update book (ISBN: {isbn}) set title: {title}");
        }
        public void UpdateAuthorOfBook(string isbn, string author)
        {
            booksByISBNs[isbn].Author = author;
            booksByISBNs[isbn].LastModificationDate = DateTime.Now;
            Log(isbn, $"update book (ISBN: {isbn}) set authors: {author}");
        }

        public void DeleteBook(string isbn)
        {
            booksByISBNs.Remove(isbn);
            logsByISBNs.Remove(isbn);
        }

        public bool ValidateISBN(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
                return false;
            return isbn.All(ch => "0123456789-".Contains(ch));
        }

        public void ShowLogs()
        {
            Console.WriteLine();
            foreach (var logs in logsByISBNs)
                foreach (var log in logs.Value)
                Console.WriteLine($"      {logs.Key}: {log.Message} | {log.Date.ToShortDateString()}--{log.Date.ToShortTimeString()}");

        }

        public void PrintBooks()
        {
            Console.WriteLine();
            foreach (var kvp in booksByISBNs)
            {
                var isbn = kvp.Key;
                var book = kvp.Value;
                Console.WriteLine(
                    $"* {book.Author ?? "<HIÁNYZÓ ADATOK>"}: {book.Title ?? "<HIÁNYZÓ ADATOK>"} (ISBN: {isbn}) [utoljára módosítva: {book.LastModificationDate.ToShortDateString()}--{book.LastModificationDate.ToShortTimeString()}]");
            }

        }

        public BookMemento CreateBookMemento(string isbn) {
            return new BookMemento

            {
                Book = booksByISBNs.ContainsKey(isbn)? booksByISBNs[isbn].Clone() : null,
                LogItems = logsByISBNs.ContainsKey(isbn)? new List<BookLogItem>(logsByISBNs[isbn]) : null,
                ISBN = isbn
            };

        }


        public void RestoreBookFromMemento(BookMemento memento)
        {
            if (memento.Book == null && booksByISBNs.ContainsKey(memento.ISBN))
                booksByISBNs.Remove(memento.ISBN);
            else
                booksByISBNs[memento.ISBN] = memento.Book;

            if (memento.LogItems == null && logsByISBNs.ContainsKey(memento.ISBN))
                logsByISBNs.Remove(memento.ISBN);
            else
                logsByISBNs[memento.ISBN] = memento.LogItems;
        }



    }

}
