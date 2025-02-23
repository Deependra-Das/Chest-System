using ChestSystem.Main;
using ChestSystem.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.UI
{
    public class UIView : GenericMonoSingleton<UIView>
    {
        [Header("Currency")]
        [SerializeField] private Image _coinsImage;
        [SerializeField] private Image _gemsImage;

        [Header("Action Buttons")]
        [SerializeField] private Button _generateChestsButton;
        [SerializeField] private Button _UndoOptionButton;

        [Header("Pop-Ups")]
        [SerializeField] private GameObject _popUpContainer;
        [SerializeField] private AcknowledgementPopUpView _acknowledgementPrefab;
        [SerializeField] private ConfirmationPopUpView _confirmationPopUpPrefab;
        [SerializeField] private NotificationPopUpView _notificationPopUpPrefab;

        private AcknowledgementPopUpView _acknowledgementPopUpView;
        private ConfirmationPopUpView _confirmationPopUpView;
        private NotificationPopUpView _notificationPopUpView;


        public void Initialize()
        {
            InitializePopUps();
            _popUpContainer.SetActive(false);
        }

        private void InitializePopUps()
        {
            _acknowledgementPopUpView = GameObject.Instantiate(_acknowledgementPrefab, _popUpContainer.transform);
            _confirmationPopUpView = GameObject.Instantiate(_confirmationPopUpPrefab, _popUpContainer.transform);
            _notificationPopUpView = GameObject.Instantiate(_notificationPopUpPrefab, _popUpContainer.transform);

            _acknowledgementPopUpView.gameObject.SetActive(false);
            _confirmationPopUpView.gameObject.SetActive(false);
            _notificationPopUpView.gameObject.SetActive(false);
        }

    }

}
