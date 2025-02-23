using ChestSystem.ChestSlot;
using ChestSystem.Main;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

namespace ChestSystem.Chest
{
    public class ChestController
    {
        private ChestModel _chestModel;
        private ChestView _chestView;
        protected ChestStateMachine _chestStateMachine;
        private ChestSlotController _chestSlotController;

        public ChestController(ChestScriptableObject chestSO, ChestView chestPrefab)
        {
            _chestModel = new ChestModel(chestSO);
            _chestView = GameObject.Instantiate(chestPrefab, GameService.Instance.GetCanvasTransform);
            _chestView.SetController(this);
            _chestView.SetChestDataOnUI();
        }

        public void Configure(ChestSlotController chestSlotController)
        {
            _chestSlotController = chestSlotController;
            _chestView.gameObject.transform.SetParent(_chestSlotController.GetSlotTransform());
            _chestView.gameObject.transform.localPosition = Vector3.zero;
            _chestView.gameObject.transform.localScale = new Vector3(1, 1, 1);
            _chestView.gameObject.SetActive(true);
        }

        protected void CreateStateMachine() => _chestStateMachine = new ChestStateMachine(this);

        public ChestModel GetChestModel { get { return _chestModel; } private set { } }
        public ChestView GetChestView { get { return _chestView; } private set { } }

        public void OnChestButtonClicked()
        {
            _chestStateMachine.OnChestButtonClick();
        }

        public void UpdateChest()
        {
            if (_chestStateMachine.GetCurrentState() != ChestStates.UNLOCKING)
                return;

            _chestStateMachine.Update();
        }

        public void UpdateUnlockingTimerText(float currentTimeLeft)
        {
            _chestView.UpdateUnlockingTimerText(currentTimeLeft);
        }

        public void ChestCollected()
        {
            _chestView.gameObject.SetActive(false);
            _chestView.gameObject.transform.SetParent(GameService.Instance.GetCanvasTransform);
            _chestSlotController.SetSlotState(ChestSlotStates.UNOCCUPIED);
            _chestSlotController = null;
            GameService.Instance.GetChestService().ReturnChestToPool(this);
        }

        public void ChangeState(ChestStates newState)
        {
            _chestStateMachine.ChangeState(newState);
        }

        public void ToggleLockedStateUI(bool value)
        {
            _chestView.ToggleLockedStateUI(value);
        }
        public void ToggleUnlockingStateUI(bool value)
        {
            _chestView.ToggleUnlockingStateUI(value);
        }
        public void ToggleQueuedStateUI(bool value)
        {
            _chestView.ToggleQueuedStateUI(value);
        }
        public void ToggleUnlockedStateUI(bool value)
        {
            _chestView.ToggleUnlockedStateUI(value);
        }

    }
}

