using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ChestSystem.UI
{
    public class AcknowledgementPopUpView : MonoBehaviour
    {
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
            gameObject.SetActive(true);
        }

        private void HideAcknowledgementPopUp()
        {
            Debug.Log("Clicked");
            gameObject.transform.parent?.gameObject.SetActive(false);
            gameObject.SetActive(false);          
        }
    }

}
