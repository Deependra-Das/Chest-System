using ChestSystem.ChestSlot;
using ChestSystem.Main;
using ChestSystem.Sound;
using ChestSystem.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ChestClick);
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

        public void UpdateGemCost(float currentTimeLeft)
        {
            _chestModel.UpdateGemCost(CalculateGemsCost(currentTimeLeft));
        }

        public int CalculateGemsCost(float currentTimeLeft)
        {
            float gemCost = currentTimeLeft / 10;
            int totalGemsCost = (int)Math.Ceiling(gemCost);

            return totalGemsCost;
        }

        public void ChestCollected()
        {
            int coinsDrop = UnityEngine.Random.Range(_chestModel.CoinsMinDrop, _chestModel.CoinsMaxDrop);
            int gemsDrop = UnityEngine.Random.Range(_chestModel.GemsMinDrop, _chestModel.GemsMaxDrop);

            GameService.Instance.GetCurrencyService().AddCoins(coinsDrop);
            GameService.Instance.GetCurrencyService().AddGems(gemsDrop);

            GameService.Instance.GetCommandInvoker().RemoveCommandFromRegistry(this);

            GameService.Instance.GetUIService().ShowAcknowledmentPopUp(this, coinsDrop, gemsDrop);

            _chestView.gameObject.SetActive(false);
            _chestView.gameObject.transform.SetParent(GameService.Instance.GetCanvasTransform);
            _chestSlotController.SetSlotState(ChestSlotStates.UNOCCUPIED);
            _chestSlotController = null;

            GameService.Instance.GetChestService().ReturnChestToPool(this);
        }

        public void ChangeChestState(ChestStates value)
        {
            _chestStateMachine.ChangeState(value);
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

        public void RemoveChestFromUnlockingQueue()
        {
            GameService.Instance.GetUnlockingQueueService().DeqeueChestAfterUnlocking();
        }

        public void ResetSlotAfterCollecting()
        {
            GameService.Instance.GetChestSlotService().ResetSlotAfterCollecting(_chestSlotController);
        }

        public void ShowConfirmationPopUp(ConfirmationType type)
        {
            GameService.Instance.GetUIService().ShowConfirmationPopUp(this, type);
        }

        public void ShowActionPopUp()
        {
            GameService.Instance.GetUIService().ShowActionPopUp(this);
        }

        public void ShowQueuedNotificationPopUp()
        {
            GameService.Instance.GetUIService().ShowNotificationPopUp(NotificationType.AlreadyQueued);
        }

        public ChestStates GetCurrentChestState()
        {
            return _chestStateMachine.GetCurrentState();
        }
    }
}

