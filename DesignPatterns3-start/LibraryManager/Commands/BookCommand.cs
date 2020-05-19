using LibraryManager.Memento;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Commands
{
    public abstract class BookCommand : ICommand
    {
        protected BookMemento memento;
        protected LibraryManager library;
        protected string isbn;

        public BookCommand(LibraryManager manager, string isbn) {
            this.library = manager;
            this.isbn = isbn;
        }

        public virtual void Execute()
        {
            memento = library.CreateBookMemento(isbn);
        }

        public virtual void UnExecute()
        {
            library.RestoreBookFromMemento(memento);
        }
    }
}
