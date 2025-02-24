using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestModel
    {
        public ChestType ChestType { get; private set; }
        public Sprite ChestLockedImage { get; private set; }
        public Sprite ChestUnlockedImage { get; private set; }
        public int UnlockDuration { get; private set; }
        public int GemsCost { get; private set; }
        public int CoinsMinDrop { get; private set; }
        public int CoinsMaxDrop { get; private set; }
        public int GemsMinDrop { get; private set; }
        public int GemsMaxDrop { get; private set; }

        public ChestModel(ChestScriptableObject chest_SO)
        {
            ChestType = chest_SO.chestType;
            ChestLockedImage = chest_SO.chestLockedImage;
            ChestUnlockedImage = chest_SO.chestUnlockedImage;
            GemsCost = chest_SO.gemsCost;
            UnlockDuration = chest_SO.unlockDuration;
            CoinsMinDrop = chest_SO.coinsMinDrop;
            CoinsMaxDrop = chest_SO.coinsMaxDrop;
            GemsMinDrop = chest_SO.gemsMinDrop;
            GemsMaxDrop = chest_SO.gemsMaxDrop;
        }

        public void UpdateGemCost(int amount)
        {
            GemsCost = amount;
        }
    }
}