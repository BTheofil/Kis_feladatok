using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Commands
{
    public class CreateBookCommand : BookCommand
    {
        public CreateBookCommand(LibraryManager library, string isbn) : base(library, isbn) {
            
        }
        public override void Execute()
        {
            base.Execute();
            library.CreateNewBook(isbn);
        }
    }
}
