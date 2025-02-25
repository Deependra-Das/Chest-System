using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        private List<ChestScriptableObject> _chestSO_List;
        private ChestController _chestController;
        private ChestPool _chestPoolObj;

        public ChestService(List<ChestScriptableObject> chestSO_List, ChestView chestPrefab) 
        {
            _chestSO_List = chestSO_List;
            _chestPoolObj = new ChestPool(chestPrefab);
        }

        public ChestController GenerateRandomChest()
        {
            ChestType randomChest = (ChestType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ChestType)).Length);
            ChestController chest = FetchChest(randomChest);
            chest.ChangeChestState(ChestStates.LOCKED);
            return chest;
        }

        private ChestController FetchChest(ChestType typeToFetch)
        {
            ChestScriptableObject fetchedData = _chestSO_List.Find(item => item.chestType == typeToFetch);

            switch (typeToFetch)
            {
                case ChestType.Common:
                    return (ChestController)_chestPoolObj.GetChest<CommonChest>(fetchedData);
                case ChestType.Rare:
                    return (ChestController)_chestPoolObj.GetChest<RareChest>(fetchedData);
                case ChestType.Epic:
                    return (ChestController)_chestPoolObj.GetChest<EpicChest>(fetchedData);
                case ChestType.Legendary:
                    return (ChestController)_chestPoolObj.GetChest<LegendaryChest>(fetchedData);
                default:
                    throw new Exception($"Failed to Create ChestController for: {typeToFetch}");
            }
        }

        public void ReturnChestToPool(ChestController chestToReturn) => _chestPoolObj.ReturnItem(chestToReturn);
    }
}
