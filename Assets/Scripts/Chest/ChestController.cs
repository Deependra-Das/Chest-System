using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestModel _chestModel;
        private ChestView _chestView;

        public ChestController(ChestScriptableObject chestSO, ChestView chestPrefab, Transform contentTransform)
        {
            _chestModel = new ChestModel(chestSO);

            _chestView = GameObject.Instantiate(chestPrefab, contentTransform);
            _chestView.SetController(this);
        }
    }
}

