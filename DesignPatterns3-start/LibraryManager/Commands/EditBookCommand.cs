using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Commands
{
    public class EditBookCommand : BookCommand
    {
        private List<ICommand> lista;
        public EditBookCommand(LibraryManager manager, string isbn) : base(manager, isbn)
        {
        }

        public override void Execute()
        {
            base.Execute();
        }

        public void AddCommand(ICommand c) {
            lista.Add(c);
        }
    }
}
