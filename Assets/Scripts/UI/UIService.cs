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
        private ActionPopUpView _actionView;
        private Transform _canvasTransform;

        public UIService(UIView uiPrefab, AcknowledgementPopUpView acknowledgementPrefab, ConfirmationPopUpView confirmationPrefab, NotificationPopUpView notificationPrefab, ActionPopUpView actionPrefab, Transform canvasTransform)
        {
            _canvasTransform = canvasTransform;
            _uiView = GameObject.Instantiate(uiPrefab, _canvasTransform);
            _acknowledgementView = GameObject.Instantiate(acknowledgementPrefab, _canvasTransform);
            _confirmationView = GameObject.Instantiate(confirmationPrefab, _canvasTransform);
            _actionView = GameObject.Instantiate(actionPrefab, _canvasTransform);
        }

        public void Initialize()
        {
            _uiView.Initialize();
            InitializePopUps();
        }

        private void InitializePopUps()
        {
            _acknowledgementView.HideAcknowledgementPopUp();
            _confirmationView.HideConfirmationPopUp();
            _actionView.HideActionPopUp();
        }

        public void ShowAcknowledmentPopUp(string message)
        {
            _acknowledgementView.SetAcknowledgementContent(message);
            _acknowledgementView.ShowAcknowledgementPopUp();
        }

        public void ShowConfirmationPopUp(ChestController chestController, ConfirmationType type)
        {
            _confirmationView.SetConfirmationContent(chestController, type);
            _confirmationView.ShowConfirmationPopUp();
        }
        public void ShowActionPopUp(ChestController chestController)
        {
            _actionView.SetActionPopUpContent(chestController);
            _actionView.ShowActionPopUp();
        }

        public Transform GetSlotContainerTransform { get { return _uiView.GetSlotContainerTransform; } private set { } }
    }

}
