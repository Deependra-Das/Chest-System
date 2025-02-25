using ChestSystem.Chest;
using ChestSystem.Main;
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
            GameService.Instance.GetCurrencyService().SubtractGems(_chest.GetChestModel.GemsCost);
        }

        public void Undo()
        {
            _chest.ChangeChestState(ChestStates.LOCKED);
            GameService.Instance.GetCurrencyService().AddGems(_chest.GetChestModel.GemsCost);
        }

        public ChestController GetChestController() => _chest;

    }
}
