using ChestSystem.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestModel _chestModel;
        private ChestView _chestView;

        public ChestController(ChestScriptableObject chestSO, ChestView chestPrefab)
        {
            _chestModel = new ChestModel(chestSO);
            _chestView = GameObject.Instantiate(chestPrefab, GameService.Instance.GetContentTransform);
            _chestView.SetController(this);
            _chestView.SetChestDataOnUI();
        }

        public void Configure()
        {
            _chestView.gameObject.SetActive(true);
        }

        public void ChestOpened()
        {
            _chestView.gameObject.SetActive(false);
            GameService.Instance.GetChestService().ReturnChestToPool(this);
        }

        public ChestModel GetChestModel { get { return _chestModel; } private set { } }
        public ChestView GetChestView { get { return _chestView; } private set { } }
    }
}

