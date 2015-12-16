namespace PSP3.Commands
{
    public interface ICommandProcessor
    {
        void Execute(ICommand cmd);
        void UndoLast();
    }
}