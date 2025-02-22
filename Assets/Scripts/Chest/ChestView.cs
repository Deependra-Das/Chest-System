using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        [Header("Prefab Data")]
        [SerializeField] private Button _chestButton;
        [SerializeField] private Image _commonBG;
        [SerializeField] private Image _rareBG;
        [SerializeField] private Image _epicBG;
        [SerializeField] private Image _legendaryBG;
        [SerializeField] private Image _rarityImage;
        [SerializeField] private Image _chestImage;

        [Header("Locked State")]
        [SerializeField] private GameObject _lockedStateToggle;
        [SerializeField] private TextMeshProUGUI _lockedDurationText;

        [Header("Unlocked State")]
        [SerializeField] private GameObject _unlockingStateToggle;
        [SerializeField] private TextMeshProUGUI _unlockingTimerText;
        [SerializeField] private Image _unlockingClockImage;
        [SerializeField] private TextMeshProUGUI _gemCostText;
        [SerializeField] private Image _gemImage;

        [Header("Queued State")]
        [SerializeField] private GameObject _queuedStateToggle;
        [SerializeField] private TextMeshProUGUI _queuedDurationText;


        private ChestController _chestController;

        public void SetController(ChestController controller)
        {
            _chestController = controller;
            SetChestDataOnUI();
            SetListeners();
        }

        private void SetListeners()
        {
            _chestButton.onClick.AddListener(CheckClicked);
        }

        private void CheckClicked()
        {
            _chestController.ChestOpened();
        }

        public void SetChestDataOnUI()
        {
            _lockedDurationText.text = FormatTime(_chestController.GetChestModel.UnlockDuration).ToString();
            _unlockingTimerText.text = FormatTime(_chestController.GetChestModel.UnlockDuration).ToString();
            _queuedDurationText.text = FormatTime(_chestController.GetChestModel.UnlockDuration).ToString();
            _gemCostText.text = _chestController.GetChestModel.GemsCost.ToString();
        }

        public string FormatTime(int minutes)
        {
            int hours = minutes / 60;
            int remainingMinutes = minutes % 60;
            string formattedTime = string.Format("{0:D2}h {1:D2}m", hours, remainingMinutes);

            return formattedTime;
        }

    }
}
