using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    [CreateAssetMenu(fileName = "Chest_SO", menuName = "ScriptableObjects/Chest_SO")]
    public class ChestScriptableObject : ScriptableObject
    {
        [Header("Chest Properties")]
        public ChestType chestType;
        public Sprite chestLockedImage;
        public Sprite chestUnlockedImage;
        public int unlockDuration;
        public int gemsCost;

        [Header("Chest Drops")]
        public int coinsMinDrop;
        public int coinsMaxDrop;
        public int gemsMinDrop;
        public int gemsMaxDrop;

    }
}