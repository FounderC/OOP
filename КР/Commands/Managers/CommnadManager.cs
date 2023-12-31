﻿using System;
using System.Collections.Generic;
using КР.Commands.Base;
using КР.Models;

namespace КР.Commands.Managers
{
    public class CommandManager
    {
        public void AddCommand(ICommand command)
        {
            Commands.Add(command);
        }

        public void DisplayCommands()
        {
            for (var i = 0; i < Commands.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Commands[i].GetCommandInfo()}");
            }
        }

        public void ExecuteCommand(int index, User user)
        {
            if (index >= 0 && index < Commands.Count)
            {
                Commands[index].Execute(user);
            }
            else
            {
                Console.WriteLine("Некоректний вибір команди.");
            }
        }

        public List<ICommand> Commands { get; } = new List<ICommand>();
    }
}