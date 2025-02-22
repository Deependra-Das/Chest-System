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
        private ChestStateMachine _chestStateMachine;
        public ChestController(ChestScriptableObject chestSO, ChestView chestPrefab)
        {
            _chestModel = new ChestModel(chestSO);
            _chestView = GameObject.Instantiate(chestPrefab, GameService.Instance.GetCanvasTransform);
            _chestView.SetController(this);
            _chestView.SetChestDataOnUI();
        }

        public void Configure(Transform parentTransform)
        {
            _chestView.gameObject.transform.SetParent(parentTransform);
            _chestView.gameObject.transform.localPosition = Vector3.zero;
            _chestView.gameObject.transform.localScale = new Vector3(1, 1, 1);
            _chestView.gameObject.SetActive(true);
        }

        public void ChestOpened()
        {
            _chestView.gameObject.SetActive(false);
            _chestView.gameObject.transform.SetParent(GameService.Instance.GetCanvasTransform);
            GameService.Instance.GetChestService().ReturnChestToPool(this);
        }

        public ChestModel GetChestModel { get { return _chestModel; } private set { } }
        public ChestView GetChestView { get { return _chestView; } private set { } }
    }
}

