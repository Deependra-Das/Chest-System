using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
                    _notificationMessageText.text = "All the slots are Occupied. Unlock & Collect a Chest to free one of the slots";
                    break;

            }
            SetListeners();
        }

        private void SetListeners()
        {
            _okButton.onClick.RemoveAllListeners();
            _okButton.onClick.AddListener(HideNotificationPopUp);
        }

        public void ShowNotificationPopUp()
        {
            _notificationContainer.SetActive(true);
        }

        public void HideNotificationPopUp()
        {
            _notificationContainer.SetActive(false);
        }
    }
}

