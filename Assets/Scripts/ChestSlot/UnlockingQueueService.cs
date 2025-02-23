using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.ChestSlot
{
    public class UnlockingQueueService : GenericMonoSingleton<UnlockingQueueService>
    {
        private Queue<ChestSlotController> slotQueue;
        private bool _isProcessing;
        public UnlockingQueueService(int slotQueueSize)
        {
            slotQueue = new Queue<ChestSlotController>(slotQueueSize);
            _isProcessing = false;
        }

        public void EnqueueChestForUnlocking(ChestSlotController chestSlot)
        {
            slotQueue.Enqueue(chestSlot);
        }

        public void UpdateUnlockingSlotQueue()
        {
            ProcessNextChestSlot();
        }

        public void ProcessNextChestSlot()
        {
            if (slotQueue.Count > 0 && _isProcessing == false)
            {
                ChestSlotController FrontChestInQueue = slotQueue.Peek();
                FrontChestInQueue.GetChestStoredInSlot().ChangeChestState(ChestStates.UNLOCKING);
                _isProcessing = true;
            }
        }
        public void DeqeueChestAfterUnlocking()
        {
            slotQueue.Dequeue();
            _isProcessing = false;
        }

        public bool IsUnlockingSlotQueueEmpty()
        {
            if(slotQueue.Count > 0)
            {
                return false;
            }
            return true;
        }

    }

}

