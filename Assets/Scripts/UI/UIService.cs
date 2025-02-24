using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.ChestSlot
{
    public class UIService
    {
        private UIView _uiView;
        private AcknowledgementPopUpView _acknowledgementView;
        private ConfirmationPopUpView _confirmationView;
        private NotificationPopUpView _notificationView;
        private Transform _canvasTransform;

        public UIService(UIView uiPrefab, AcknowledgementPopUpView acknowledgementPrefab, ConfirmationPopUpView confirmationPrefab, NotificationPopUpView notificationPrefab, Transform canvasTransform)
        {
            _canvasTransform = canvasTransform;
            _uiView = GameObject.Instantiate(uiPrefab, _canvasTransform);
            _acknowledgementView = GameObject.Instantiate(acknowledgementPrefab, _canvasTransform);
            _confirmationView = GameObject.Instantiate(confirmationPrefab, _canvasTransform);
        }

        public void Initialize()
        {
            _uiView.Initialize();
            InitializePopUps();
        }

        private void InitializePopUps()
        {
            _acknowledgementView.gameObject.SetActive(false);
            _confirmationView.gameObject.SetActive(false);
        }

        public void ShowAcknowledmentPopUp(string message)
        {
            _acknowledgementView.SetAcknowledgementContent(message);
            _acknowledgementView.ShowAcknowledgementPopUp();
        }

        public void ShowConfirmationPopUp(ChestController chestController, ChestModel chestModel, ChestStates state, ConfirmationType type)
        {
            _confirmationView.SetConfirmationContent(chestController, chestModel, state, type);
            _confirmationView.ShowConfirmationPopUp();
        }

        public Transform GetSlotContainerTransform { get { return _uiView.GetSlotContainerTransform; } private set { } }
    }

}
