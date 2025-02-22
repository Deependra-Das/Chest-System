using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestService
    {
        private List<ChestScriptableObject> _chestSO_List;
        private ChestController _chestController;

        public ChestService(List<ChestScriptableObject> chestSO_List, ChestView chestPrefab, Transform contentTransform) 
        {
            _chestController = new ChestController(chestSO_List[0],chestPrefab, contentTransform);
        }
    }
}
