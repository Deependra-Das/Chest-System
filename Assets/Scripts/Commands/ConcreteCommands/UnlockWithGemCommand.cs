using ChestSystem.Chest;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Commands
{
    public class UnlockWithGemCommand : ICommand
    {
        private ChestController _chest;
        public UnlockWithGemCommand(ChestController chest)
        {
            _chest=chest;
        }

        public void Execute()
        {
            _chest.ChangeChestState(ChestStates.UNLOCKED);
        }

        public void Undo()
        {
            _chest.ChangeChestState(ChestStates.LOCKED);
        }

        public ChestController GetChestController() => _chest;

    }
}
