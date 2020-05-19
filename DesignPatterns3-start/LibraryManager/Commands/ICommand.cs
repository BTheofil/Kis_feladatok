using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Commands
{
    interface ICommand
    {
        void Execute();
        void UnExecute();
    }
}
