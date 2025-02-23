using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.ChestSlot
{
    public class ChestSlotService
    {
        private List<ChestSlotController> _chestSlotList;
        private ChestSlotQueueController _chestSlotQueueObj;
        public ChestSlotService(ChestSlotView chestSlotPrefab, int slotCount)
        {
            _chestSlotList = new List<ChestSlotController>(slotCount);
            CreateChestSlots(chestSlotPrefab, slotCount);
            _chestSlotQueueObj = new ChestSlotQueueController(slotCount);
        }

        public void CreateChestSlots(ChestSlotView chestSlotPrefab, int slotCount)
        {
            for(int i=0; i<slotCount;i++)
            {
                ChestSlotController newSlot = new ChestSlotController(chestSlotPrefab);
                _chestSlotList.Add(newSlot);
            }
        }

        public ChestSlotController GetSlotAtPosition(int i)
        {
            return _chestSlotList[i];
        }

        public int GetNumberOfSlots()
        {
            return _chestSlotList.Count;
        }
        public ChestSlotController GetVacantSlot()
        {
            foreach (ChestSlotController slot in _chestSlotList)
            {
                if (slot.IsSlotAvailable())
                {
                    return slot;
                }
            }
            return null;
        }

        public void EnqueueChestForUnlocking(ChestSlotController chestSlot)
        {
            _chestSlotQueueObj.EnqueueChestForUnlocking(chestSlot);
        }

        public void ProcessNextChestSlot()
        {

        }
        public void DeqeueChestAfterUnlocking(ChestSlotController chestSlot)
        {
            _chestSlotQueueObj.DeqeueChestForUnlocking();        
        }

        public void ResetSlotAfterCollecting(ChestSlotController chestSlot)
        {
            _chestSlotList.Remove(chestSlot);
            _chestSlotList.Add(chestSlot);
            chestSlot.GetSlotTransform().SetAsLastSibling();
        }
    }

}
