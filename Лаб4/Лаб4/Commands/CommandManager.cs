using System;
using System.Collections.Generic;

namespace Лаб4.Commands
{
    public class CommandManager
    {
        private List<ICommand> _commands;

        public void AddCommand(ICommand command)
        {
            _commands.Add(command);
        }

        public void DisplayCommands()
        {
            for (int i = 0; i < _commands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_commands[i].GetCommandInfo()}");
            }
        }

        public void ExecuteCommand(int index)
        {
            if (index >= 0 && index < _commands.Count)
            {
                _commands[index].Execute();
            }
            else
            {
                Console.WriteLine("Некоректний вибір команди.");
            }
        }
        
        public List<ICommand> Commands
        {
            get { return _commands; }
        }
    }
}