using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.Commands;
using ChestSystem.Sound;

namespace ChestSystem.UI
{
    public class ConfirmationPopUpView : MonoBehaviour
    {
        [SerializeField] private GameObject _confirmationContainer;
        [SerializeField] private Image _chestImage;
        [SerializeField] private TextMeshProUGUI _chestTypeText;
        [SerializeField] private Image _coinImage;
        [SerializeField] private Image _gemImage;
        [SerializeField] private TextMeshProUGUI _possiblecoinsText;
        [SerializeField] private TextMeshProUGUI _possiblegemsText;
        [SerializeField] private TextMeshProUGUI _confirmationMessageText;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;

        private ChestController _currentChest;

        public void SetConfirmationContent(ChestController chestController, ConfirmationType type)
        {
            _currentChest = chestController;
            _chestImage.sprite = chestController.GetChestModel.ChestLockedImage;

            _chestTypeText.text = chestController.GetChestModel.ChestType.ToString()+" : "+ chestController.GetCurrentChestState().ToString();
            _possiblecoinsText.text = chestController.GetChestModel.CoinsMinDrop.ToString()+"-"+ chestController.GetChestModel.CoinsMaxDrop.ToString();
            _possiblegemsText.text = chestController.GetChestModel.GemsMinDrop.ToString()+"-"+chestController.GetChestModel.GemsMaxDrop.ToString();

            _confirmButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.AddListener(CancelButtonClicked);

            switch (type)
            {
                case ConfirmationType.StartUnlocking:
                    _confirmationMessageText.text = "Do you want to start unlocking with timer ?";
                    _confirmButton.onClick.AddListener(UnlockActionClicked);
                    break;
                case ConfirmationType.Queuing:
                    _confirmationMessageText.text = "Only one chest can be unlocking at a time.<br>Do you want to queue this chest for unlocking ?";
                    _confirmButton.onClick.AddListener(QueueActionClicked);
                    break;
                case ConfirmationType.UnlockWithGems:
                    _confirmationMessageText.text = "Do you want to spend "+chestController.GetChestModel.GemsCost.ToString()+" gems to unlock it ?";
                    _confirmButton.onClick.AddListener(GemUnlockActionClicked);
                    break;
                case ConfirmationType.UndoGemSpent:
                    _confirmationMessageText.text = "Do you want to get back " + chestController.GetChestModel.GemsCost.ToString() + " gems spent on Unlocking this chest ?<br>Note: This will Re-Lock the Chest";
                    _confirmButton.onClick.AddListener(UndoGemUnlockActionClicked);
                    break;
            }
        }

        private void UnlockActionClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            _currentChest.ChangeChestState(ChestStates.UNLOCKING);
            GameService.Instance.GetUnlockingQueueService().EnqueueChestForUnlocking(_currentChest);
            HideConfirmationPopUp();
        }

        private void QueueActionClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            _currentChest.ChangeChestState(ChestStates.QUEUED);
            GameService.Instance.GetUnlockingQueueService().EnqueueChestForUnlocking(_currentChest);
            HideConfirmationPopUp();
        }

        private void GemUnlockActionClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);

            if (GameService.Instance.GetCurrencyService().GemsOwned>=_currentChest.GetChestModel.GemsCost)
            {
                ICommand unlockWithGemCommand = new UnlockWithGemCommand(_currentChest);
                GameService.Instance.GetCommandInvoker().ProcessCommand(unlockWithGemCommand);
            }
            else
            {
                GameService.Instance.GetUIService().ShowNotificationPopUp(NotificationType.InsufficientGem);
            }
    
            HideConfirmationPopUp();
        }

        private void UndoGemUnlockActionClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            GameService.Instance.GetCommandInvoker().Undo(_currentChest);
            HideConfirmationPopUp();
        }

        public void ShowConfirmationPopUp()
        {
            _confirmationContainer.SetActive(true);
        }

        private void CancelButtonClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            HideConfirmationPopUp();
        }

        public void HideConfirmationPopUp()
        {
            _confirmationContainer.SetActive(false);
        }

    }
}
