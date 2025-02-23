using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.ChestSlot
{
    public class ChestSlotQueueController
    {
        private Queue<ChestSlotController> slotQueue;

        public ChestSlotQueueController(int slotQueueSize)
        {
            slotQueue = new Queue<ChestSlotController>(slotQueueSize);
        }

        public void EnqueueChestForUnlocking(ChestSlotController chestSlot)
        {
            slotQueue.Enqueue(chestSlot);
        }

        public void ProcessNextChestSlot()
        {

        }
        public void DeqeueChestForUnlocking()
        {
            slotQueue.Dequeue();
        }
    }

}

