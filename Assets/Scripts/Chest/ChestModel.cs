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
        public int CoinsDrop { get; private set; }
        public int GemsDrop { get; private set; }

        public ChestModel(ChestScriptableObject chest_SO)
        {
            ChestType = chest_SO.chestType;
            ChestLockedImage = chest_SO.chestLockedImage;
            ChestUnlockedImage = chest_SO.chestUnlockedImage;
            UnlockDuration = chest_SO.unlockDuration;
            GemsCost = chest_SO.gemsCost;

            CoinsDrop = Random.Range(chest_SO.coinsMinDrop, chest_SO.coinsMaxDrop);
            GemsDrop = Random.Range(chest_SO.gemsMinDrop, chest_SO.gemsMaxDrop);
        }
    }
}