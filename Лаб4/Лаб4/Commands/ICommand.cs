namespace Лаб4.Commands
{
    public interface ICommand
    {
        void Execute();
        string GetCommandInfo();
    }
}