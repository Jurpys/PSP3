namespace PSP3.Commands
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
}