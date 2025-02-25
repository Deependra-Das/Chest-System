using ChestSystem.Chest;
using ChestSystem.Commands;
using ChestSystem.Main;
using System.Linq;
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
                    return;
                }
            }
        }

        public void RemoveCommandFromRegistry(ChestController controller)
        {
            for (int i = _commandRegistry.Count - 1; i >= 0; i--)
            {
                ICommand command = _commandRegistry[i];

                if (command.GetChestController() == controller)
                {
                    _commandRegistry.RemoveAt(i);
                    return;
                }
            }
        }
        
        public void PrintRegistry()
        {
            Debug.Log("Command History:");
            for (int i = 0; i < _commandRegistry.Count; i++)
            {
                Debug.Log($"Command {i}: {_commandRegistry[i].GetType().Name}");
            }
        }

        public List<ChestController> GetUnlockGemRegistryData()
        {
            List<ICommand> unlockGemRegistryData = _commandRegistry.Where(x => x.GetType().Name == "UnlockWithGemCommand").ToList();

            List<ChestController> chestswithUnclockGemCommand = unlockGemRegistryData.Select(p => p.GetChestController()).ToList();

            return chestswithUnclockGemCommand;
        }
    }

}
