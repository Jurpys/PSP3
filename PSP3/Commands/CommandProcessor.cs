using System.Collections.Generic;

namespace PSP3.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        Stack<ICommand> _commands = new Stack<ICommand>();

        public void Execute(ICommand command)
        {
            command.Execute();
            _commands.Push(command);
        }

        public void UndoLast()
        {
            var command = _commands.Pop();
            command.Undo();
        }  
    }
}