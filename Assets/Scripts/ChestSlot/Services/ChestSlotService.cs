using System.Collections.Generic;

namespace ChestSystem.ChestSlot
{
    public class ChestSlotService
    {
        private List<ChestSlotController> _chestSlotList;

        public ChestSlotService(ChestSlotView chestSlotPrefab, int slotCount)
        {
            _chestSlotList = new List<ChestSlotController>(slotCount);
            CreateChestSlots(chestSlotPrefab, slotCount);
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

        public void ResetSlotAfterCollecting(ChestSlotController chestSlot)
        {
            _chestSlotList.Remove(chestSlot);
            _chestSlotList.Add(chestSlot);
            chestSlot.GetSlotTransform().SetAsLastSibling();
        }
              
    }

}
