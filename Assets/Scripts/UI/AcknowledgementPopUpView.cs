using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestSystem.Utilities;

namespace ChestSystem.UI
{
    public class AcknowledgementPopUpView : MonoBehaviour
    {
        [SerializeField] private GameObject _acknowledgementContainer;
        [SerializeField] private TextMeshProUGUI _acknowledgementMessageText;
        [SerializeField] private Button _acknowledgementButton;

        private void Start()
        {
            _acknowledgementButton.onClick.AddListener(HideAcknowledgementPopUp);
        }

        public void SetAcknowledgementContent(string message)
        {
            _acknowledgementMessageText.text = message;
        }

        public void ShowAcknowledgementPopUp()
        {
            _acknowledgementContainer.SetActive(true);
        }

        public void HideAcknowledgementPopUp()
        {
            _acknowledgementContainer.SetActive(false);          
        }
    }

}
