using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryManager.Commands
{
    class CommandProcessor
    {
        private Stack<ICommand> commands = new Stack<ICommand>();

        public void AddAndExecute(ICommand command) {
            commands.Push(command);
            command.Execute();
        }

        public void Undo() {
            if (commands.Any())
            {
                var command = commands.Pop();
                command.UnExecute();
            }
        }
    }
}
