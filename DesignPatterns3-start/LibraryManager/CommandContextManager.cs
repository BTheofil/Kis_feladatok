using LibraryManager.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager
{
    public class CommandContextManager
    {
        private readonly LibraryManager libraryManager = new LibraryManager();
        private readonly CommandProcessor commandProcessor = new CommandProcessor();

        private string editedISBN = null;
        private bool isInEditBookMode => !string.IsNullOrEmpty(editedISBN);

        #region utasítások

        private bool validateNotInEditMode() {
            if (isInEditBookMode) {
                Console.WriteLine("Nem elerheto szerkeztes modban.");
                return false;
            }
            return true;
        }
        public void Save(string path)
        {
            libraryManager.Save(path);
        }

        public void Load(string path)
        {
            if (!validateNotInEditMode()) return;
            libraryManager.Load(path);
        }

        public void CreateNewBook(string isbn)
        {
            if (!validateNotInEditMode()) return;

            if (!libraryManager.ValidateISBN(isbn))
            {
                Console.WriteLine("Hibás ISBN szám");
                return;
            }

            if (libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv már van az adatbázisban");
                return;
            }

            commandProcessor.AddAndExecute(new CreateBookCommand(libraryManager, isbn));
        }

        public void DeleteBook(string isbn)
        {
            if (!validateNotInEditMode()) return;

            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Nincs ilyen ISBN számú könyv az adatbázisban");
                return;
            }

            commandProcessor.AddAndExecute(new DeleteBookCommand(libraryManager, isbn));

        }

        public void UpdateTitleOfBook(string isbn, string title)
        {
            if (!validateNotInEditMode()) return;

            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv nincs az adatbázisban");
                return;
            }

            commandProcessor.AddAndExecute(new UpdateTitleCommand(libraryManager, isbn, title));
        }

        public void UpdateAuthorOfBook(string isbn, string author)
        {
            if (!validateNotInEditMode()) return;

            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv nincs az adatbázisban");
                return;
            }

            commandProcessor.AddAndExecute(new UpdateAuthorCommand(libraryManager, isbn,author));
        }

        public void ShowLogs()
        {

            libraryManager.ShowLogs();
        }

        public void Undo()
        {
            commandProcessor.Undo();
        }

        public void PrintBooks()
        {
            libraryManager.PrintBooks();
        }

        #endregion

        #region Összetett szerkesztés utasítások

        public void StartEditingBook(string isbn)
        {
            if (!validateNotInEditMode()) return;

            if (!libraryManager.IsISBNInLibrary(isbn))
            {
                Console.WriteLine("Ilyen ISBN számú könyv nincs az adatbázisban");
                return;
            }
            editedISBN = isbn;
        }

        public void UpdateEditedBookTitle(string title)
        {
            if (!validateInEditMode()) return;

            commandProcessor.AddAndExecute(new UpdateTitleCommand(libraryManager, editedISBN,title));

        }

        public void UpdateEditedBookAuthor(string author)
        {
            if (!validateInEditMode()) return;

            commandProcessor.AddAndExecute(new UpdateAuthorCommand(libraryManager, editedISBN,author));

        }

        public void FinishEditingBook()
        {
            if (!validateInEditMode()) return;

            editedISBN = null;
        }

        private bool validateInEditMode() {
            if (!isInEditBookMode)
            {
                Console.WriteLine("Elobb valassz konyvet.");
                return false;
            }
            return true;
        }

        #endregion
    }
}
