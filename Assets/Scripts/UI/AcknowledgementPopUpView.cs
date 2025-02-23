using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestSystem.Utilities;

namespace ChestSystem.UI
{
    public class AcknowledgementPopUpView : GenericMonoSingleton<AcknowledgementPopUpView>
    {
        [SerializeField] private GameObject _acknowledgementContainer;
        [SerializeField] private TextMeshProUGUI _acknowledgementMessageText;
        [SerializeField] private Button _acknowledgementButton;

        private void Start()
        {
            _acknowledgementButton.onClick.AddListener(HideAcknowledgementPopUp);
        }

        public void SetShowAcknowledgementMessage(string message)
        {
            _acknowledgementMessageText.text = message;
        }

        public void ShowAcknowledgementPopUp()
        {
            _acknowledgementContainer.SetActive(true);
        }

        private void HideAcknowledgementPopUp()
        {
            Debug.Log("Clicked");
            _acknowledgementContainer.SetActive(false);          
        }
    }

}
