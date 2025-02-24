using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.ChestSlot
{
    public class UnlockingQueueService
    {
        private Queue<ChestController> chestQueue;
        private bool _isProcessing;
        public UnlockingQueueService(int queueSize)
        {
            chestQueue = new Queue<ChestController>(queueSize);
            _isProcessing = false;
        }

        public void EnqueueChestForUnlocking(ChestController chestSlot)
        {
            chestQueue.Enqueue(chestSlot);
        }

        public void UpdateUnlockingSlotQueue()
        {
            if(chestQueue.Count > 0 && _isProcessing == false)
            {
                ChestController frontChestInQueue = chestQueue.Peek();

                if (frontChestInQueue.GetCurrentChestState() == ChestStates.UNLOCKING)
                {
                    ProcessCurrentChestSlot();
                }
                else if (frontChestInQueue.GetCurrentChestState() == ChestStates.QUEUED)
                {
                    PrepareNextChestSlot();
                }
            }
        }

        public void ProcessCurrentChestSlot()
        {
            _isProcessing = true;
        }

        public void PrepareNextChestSlot()
        {
            ChestController frontChestInQueue = chestQueue.Peek();
            frontChestInQueue.ChangeChestState(ChestStates.UNLOCKING);
        }

        public void DeqeueChestAfterUnlocking()
        {
            Debug.Log(_isProcessing.ToString());
            chestQueue.Dequeue();
            _isProcessing = false;
        }

        public bool IsUnlockingSlotQueueEmpty()
        {
            if(chestQueue.Count > 0)
            {
                return false;
            }
            return true;
        }

    }

}

