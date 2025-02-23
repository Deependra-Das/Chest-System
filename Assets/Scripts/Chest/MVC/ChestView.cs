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

        [Header("Unlocking State")]
        [SerializeField] private GameObject _unlockingStateToggle;
        [SerializeField] private TextMeshProUGUI _unlockingTimerText;
        [SerializeField] private Image _unlockingClockImage;
        [SerializeField] private TextMeshProUGUI _gemCostText;
        [SerializeField] private Image _gemImage;

        [Header("Queued State")]
        [SerializeField] private GameObject _queuedStateToggle;
        [SerializeField] private TextMeshProUGUI _queuedDurationText;

        [Header("Unlocked State")]
        [SerializeField] private GameObject _unlockedStateToggle;

        private ChestController _chestController;

        public void SetController(ChestController controller)
        {
            _chestController = controller;
            InitializeChestView();
        }

        public void InitializeChestView()
        {
            SetListeners();
            SetChestDataOnUI();
            DisableAllStatePanels();
        }

        private void SetListeners()
        {
            _chestButton.onClick.AddListener(_chestController.OnChestButtonClicked);
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

        public void DisableAllStatePanels()
        {
            _lockedStateToggle.gameObject.SetActive(false);
            _unlockingStateToggle.gameObject.SetActive(false);
            _queuedStateToggle.gameObject.SetActive(false);
            _unlockedStateToggle.gameObject.SetActive(false);
        }

        private void Update() => _chestController?.UpdateChest();

        public void UpdateUnlockingTimerText(float currentTimeLeft)
        {
            _unlockingTimerText.text = FormatTime((int)currentTimeLeft);
        }  

        public void ToggleLockedStateUI(bool value)
        {
            _lockedStateToggle.gameObject.SetActive(value);
        }
        public void ToggleUnlockingStateUI(bool value)
        {
            _unlockingStateToggle.gameObject.SetActive(value);
        }
        public void ToggleQueuedStateUI(bool value)
        {
            _queuedStateToggle.gameObject.SetActive(value);
        }

        public void ToggleUnlockedStateUI(bool value)
        {
            _unlockedStateToggle.gameObject.SetActive(value);
        }
 

    }
}
