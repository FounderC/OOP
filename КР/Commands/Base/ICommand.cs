using КР.Models;

namespace КР.Commands.Base
{
    public interface ICommand
    {
        void Execute(User user);
        string GetCommandInfo();
    }
}