using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestSystem.Main;
using ChestSystem.Sound;

namespace ChestSystem.UI
{
    public class NotificationPopUpView : MonoBehaviour
    {
        [SerializeField] private GameObject _notificationContainer;
        [SerializeField] private TextMeshProUGUI _notificationMessageText;
        [SerializeField] private Button _okButton;

        public void SetNotificationContent(NotificationType type)
        {
            switch(type)
            {
                case NotificationType.InsufficientGem:
                    _notificationMessageText.text = "You don't have sufficient Gems for this Action";
                    break;
                case NotificationType.SlotNotAvailable:
                    _notificationMessageText.text = "All the slots are Occupied.<br>Unlock & Collect a Chest to free one of the slots";
                    break;
                case NotificationType.AlreadyQueued:
                    _notificationMessageText.text = "This Chest is already Queued for Unlocking with Timer.";
                    break;

            }
            SetListeners();
        }

        private void SetListeners()
        {
            _okButton.onClick.RemoveAllListeners();
            _okButton.onClick.AddListener(NotificationButtonClicked);
        }

        public void ShowNotificationPopUp()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ActionDeniedClick);
            _notificationContainer.SetActive(true);
        }

        private void NotificationButtonClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            HideNotificationPopUp();
        }

        public void HideNotificationPopUp()
        {
            _notificationContainer.SetActive(false);
        }
    }
}

