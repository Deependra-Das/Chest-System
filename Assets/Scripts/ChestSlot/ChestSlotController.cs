using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using ChestSystem.Chest;
using ChestSystem.Main;

namespace ChestSystem.ChestSlot
{
    public class ChestSlotController
    {
        private ChestSlotView _chestSlotView;
        private ChestSlotStates _chestSlotState;
        private ChestController _chestObj;
        public ChestSlotController(ChestSlotView chestSlotPrefab)
        {
            _chestSlotView = GameObject.Instantiate(chestSlotPrefab, GameService.Instance.GetUIService().GetSlotContainerTransform);
            _chestSlotView.SetController(this);
            _chestSlotState = ChestSlotStates.UNOCCUPIED;
            _chestObj = null;
        }

        public bool IsSlotAvailable()
        {
            if(_chestSlotState==ChestSlotStates.UNOCCUPIED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetSlotState(ChestSlotStates value)
        {
            _chestSlotState=value;
        }

        public Transform GetSlotTransform()
        {
            return _chestSlotView.GetSlotTransform();
        }

        public void AddChestToSlot(ChestController chestController)
        {
            if(IsSlotAvailable())
            {
                _chestObj = chestController;
            }
            else
            {
                throw new Exception($"Chest Slot is Already Occupied");
            }
        }

        public void RemoveChestFromSlot()
        {
            _chestObj = null;
        }

        public ChestController GetChestStoredInSlot()
        {
            return _chestObj;
        }
    }

}

