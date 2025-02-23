using ChestSystem.Chest;
using ChestSystem.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.ChestSlot
{
    public class ChestSlotController
    {
        private ChestSlotView _chestSlotView;
        private ChestSlotStates _chestSlotState;

        public ChestSlotController(ChestSlotView chestSlotPrefab)
        {
            _chestSlotView = GameObject.Instantiate(chestSlotPrefab, GameService.Instance.GetSlotContentTransform);
            _chestSlotView.SetController(this);
            _chestSlotState = ChestSlotStates.UNOCCUPIED;
        }

        public bool IsSlotAvailable()
        {
            if(_chestSlotState==ChestSlotStates.OCCUPIED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}

