using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestSystem.Chest;
using ChestSystem.Main;

namespace ChestSystem.UI
{

    public class ActionPopUpView : MonoBehaviour
    {
        [SerializeField] private GameObject _actionPopUpContainer;
        [SerializeField] private Image _chestImage;
        [SerializeField] private TextMeshProUGUI _chestTypeText;
        [SerializeField] private TextMeshProUGUI _possiblecoinsText;
        [SerializeField] private TextMeshProUGUI _possiblegemsText;
        [SerializeField] private TextMeshProUGUI _unlockButtonText;
        [SerializeField] private Button _startTimerButton;
        [SerializeField] private Button _unlockWithGemsButton;
        [SerializeField] private Button _cancelButton;

        private ChestController _currentChest;

        public void SetActionPopUpContent(ChestController chestController)
        {
            _currentChest = chestController;
            _chestImage.sprite = _currentChest.GetChestModel.ChestLockedImage;

            _chestTypeText.text = _currentChest.GetChestModel.ChestType.ToString() + " : " + _currentChest.GetCurrentChestState().ToString();
            _possiblecoinsText.text = _currentChest.GetChestModel.CoinsMinDrop.ToString() + "-" + _currentChest.GetChestModel.CoinsMaxDrop.ToString();
            _possiblegemsText.text = _currentChest.GetChestModel.GemsMinDrop.ToString() + "-" + _currentChest.GetChestModel.GemsMaxDrop.ToString();

            _unlockButtonText.text = "Unlock with "+ _currentChest.GetChestModel.GemsCost.ToString()+" Gems";
            SetListeners();
        }

        private void SetListeners()
        {
            _startTimerButton.onClick.RemoveAllListeners();
            _startTimerButton.onClick.AddListener(StartTimerButtonClicked);

            _unlockWithGemsButton.onClick.RemoveAllListeners();
            _unlockWithGemsButton.onClick.AddListener(UnlockWithGemsButtonClicked);

            _cancelButton.onClick.RemoveAllListeners();
            _cancelButton.onClick.AddListener(HideActionPopUp);
        }

        private void StartTimerButtonClicked()
        {
            if (GameService.Instance.GetUnlockingQueueService().IsUnlockingQueueEmpty())
            {
                GameService.Instance.GetUIService().ShowConfirmationPopUp(_currentChest, ConfirmationType.StartUnlocking);
            }
            else
            {
                GameService.Instance.GetUIService().ShowConfirmationPopUp(_currentChest, ConfirmationType.Queuing);
            }

            
            HideActionPopUp();
        }
        private void UnlockWithGemsButtonClicked()
        {
            if(GameService.Instance.GetCurrencyService().GemsOwned >= _currentChest.GetChestModel.GemsCost)
            {
                GameService.Instance.GetUIService().ShowConfirmationPopUp(_currentChest, ConfirmationType.UnlockWithGems);
            }
            else
            {
                Debug.Log("Not Enough Gems");
            }
           
            HideActionPopUp();
        }

        public void ShowActionPopUp()
        {
            _actionPopUpContainer.SetActive(true);
        }

        public void HideActionPopUp()
        {
            _actionPopUpContainer.SetActive(false);
        }

    }
}
