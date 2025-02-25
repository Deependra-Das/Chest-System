using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Chest;
using ChestSystem.Main;

namespace ChestSystem.ChestSlot
{
    public class UnlockingQueueService
    {
        private Queue<ChestController> chestQueue;
        private bool _isProcessing;
        private int _maxQueueSize;

        public UnlockingQueueService(int queueSize)
        {
            chestQueue = new Queue<ChestController>();
            _maxQueueSize = queueSize;
            _isProcessing = false;
        }

        public void EnqueueChestForUnlocking(ChestController chestSlot)
        {
            chestQueue.Enqueue(chestSlot);
            UpdateUnlockingSlotQueue();
        }

        public void UpdateUnlockingSlotQueue()
        {
            if (chestQueue.Count > 0 && _isProcessing == false)
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
            chestQueue.Dequeue();
            _isProcessing = false;
            UpdateUnlockingSlotQueue();
        }

        public bool IsUnlockingQueueEmpty()
        {
            if(chestQueue.Count > 0)
            {
                return false;
            }
            return true;
        }

        public bool IsUnlockingQueueFull()
        {
            if (chestQueue.Count == _maxQueueSize)
            {
                return true;
            }
            return false;
        }

    }

}

