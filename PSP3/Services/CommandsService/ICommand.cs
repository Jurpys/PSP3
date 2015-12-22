namespace PSP3.CommandsService
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        ICommand Clone();
    }
}