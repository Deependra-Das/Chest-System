using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.Sound;

namespace ChestSystem.RefundGem
{
    public class UndoOptionView : MonoBehaviour
    {
        [SerializeField] private Image _chestImage;
        [SerializeField] private TextMeshProUGUI _chestTypeText;
        [SerializeField] private TextMeshProUGUI _possibleCoinsText;
        [SerializeField] private TextMeshProUGUI _possibleGemsText;
        [SerializeField] private Button _UndoButton;

        private UndoOptionController _undoController;
        private ChestController _currentChest;

        public void SetController(UndoOptionController undoController) => _undoController = undoController;

        public void SetData(ChestController chest)
        {
            _currentChest = chest;
            _chestImage.sprite = _currentChest.GetChestModel.ChestLockedImage;
            _chestTypeText.text = _currentChest.GetChestModel.ChestType.ToString();
            _possibleCoinsText.text = _currentChest.GetChestModel.CoinsMinDrop.ToString()+"-"+ _currentChest.GetChestModel.CoinsMaxDrop.ToString();
            _possibleGemsText.text = _currentChest.GetChestModel.GemsMinDrop.ToString() + "-" + _currentChest.GetChestModel.GemsMaxDrop.ToString();
            SetButtonListner();
        }

        public void SetButtonListner()
        {
            _UndoButton.onClick.RemoveAllListeners();
            _UndoButton.onClick.AddListener(UndoButtonClicked);
        }

        public void UndoButtonClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            GameService.Instance.GetUIService().ShowConfirmationPopUp(_currentChest, UI.ConfirmationType.UndoGemSpent);
            GameService.Instance.GetRefundGemService().HideUndoGemUnlockPanel();
        }
    }
}

