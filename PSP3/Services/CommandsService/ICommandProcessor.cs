namespace PSP3.CommandsService
{
    public interface ICommandProcessor
    {
        void Execute(ICommand cmd);
        void UndoLast();
    }
}