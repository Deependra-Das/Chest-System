using ChestSystem.Chest;
using ChestSystem.Commands;
using ChestSystem.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Commands
{
    public class CommandInvoker
    {
        private List<ICommand> _commandRegistry = new List<ICommand>();

        public void ProcessCommand(ICommand commandToProcess)
        {
            ExecuteCommand(commandToProcess);
            RegisterCommand(commandToProcess);
        }

        public void ExecuteCommand(ICommand commandToExecute) => commandToExecute.Execute();
        public void RegisterCommand(ICommand commandToRegister) => _commandRegistry.Add(commandToRegister);
        public void Undo(ChestController controller)
        {
            for (int i = _commandRegistry.Count - 1; i >= 0; i--)
            {
                ICommand command = _commandRegistry[i];

                if (command.GetChestController() == controller)
                {
                    command.Undo();
                    _commandRegistry.RemoveAt(i);
                    Debug.Log($"Undo command was sucessful");
                    return;
                }
            }

            Debug.Log($"No command found for the chest to undo.");
        }

        public void RemoveCommandFromRegistry(ChestController controller)
        {
            for (int i = _commandRegistry.Count - 1; i >= 0; i--)
            {
                ICommand command = _commandRegistry[i];

                if (command.GetChestController() == controller)
                {
                    _commandRegistry.RemoveAt(i);
                    Debug.Log($"Removed command");
                    return;
                }
            }

            Debug.Log($"No command found for the chest to remove.");
        }
        public void PrintRegistry()
        {
            Debug.Log("Command History:");
            for (int i = 0; i < _commandRegistry.Count; i++)
            {
                Debug.Log($"Command {i}: {_commandRegistry[i].GetType().Name}");
            }
        }
    }

}
