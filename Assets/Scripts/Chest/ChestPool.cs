using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Utilities;

namespace ChestSystem.Chest
{
    public class ChestPool : GenericObjectPool<ChestController>
    {
        private ChestScriptableObject _chestData;
        private ChestView _chestPrefab;

        public ChestPool(ChestView chestPrefab)
        {
            _chestPrefab = chestPrefab;
        }

        public ChestController GetChest<T>(ChestScriptableObject chestData) where T : ChestController
        {
            this._chestData = chestData;
            return GetItem<T>();
        }

        protected override ChestController CreateItem<T>()
        {
            if (typeof(T) == typeof(CommonChest))
            {
                return new CommonChest(_chestData, _chestPrefab);
            }
            else if (typeof(T) == typeof(RareChest))
            {
                return new RareChest(_chestData, _chestPrefab);
            }
            else if (typeof(T) == typeof(EpicChest))
            {
                return new EpicChest(_chestData, _chestPrefab);
            }
            else if (typeof(T) == typeof(LegendaryChest))
            {
                return new LegendaryChest(_chestData, _chestPrefab);
            }
            else
            {
                throw new NotSupportedException("Chest type not supported");
            }
        }
    }
}