using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestModel
    {
        public ChestType chestType { get; private set; }
        public Sprite chestLockedImage { get; private set; }
        public Sprite chestUnlockedImage { get; private set; }
        public int unlockDuration { get; private set; }
        public int coinsDrop { get; private set; }
        public int gemsDrop { get; private set; }

        public ChestModel(ChestScriptableObject chest_SO)
        {
            this.chestType = chest_SO.chestType;
            this.chestLockedImage = chest_SO.chestLockedImage;
            this.chestUnlockedImage = chest_SO.chestUnlockedImage;
            this.unlockDuration = chest_SO.unlockDuration;

            this.coinsDrop = Random.Range(chest_SO.coinsMinDrop, chest_SO.coinsMaxDrop);
            this.gemsDrop = Random.Range(chest_SO.gemsMinDrop, chest_SO.gemsMaxDrop);
        }
    }
}