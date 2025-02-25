using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestSystem.Chest;

namespace ChestSystem.UI
{
    public class AcknowledgementPopUpView : MonoBehaviour
    {
        [SerializeField] private GameObject _acknowledgementContainer;
        [SerializeField] private Image _chestImage;
        [SerializeField] private TextMeshProUGUI _coinsDropText;
        [SerializeField] private TextMeshProUGUI _gemsDropText;
        [SerializeField] private TextMeshProUGUI _acknowledgementMessageText;
        [SerializeField] private Button _acknowledgementButton;

        public void SetAcknowledgementContent(ChestController chestController, int coinDrop, int gemDrop)
        {
            _chestImage.sprite = chestController.GetChestModel.ChestLockedImage;
            _coinsDropText.text = coinDrop.ToString();
            _gemsDropText.text = gemDrop.ToString();
            _acknowledgementMessageText.text = chestController.GetChestModel.ChestType.ToString() +" Chest was Collected";
            SetListeners();
        }

        private void SetListeners()
        {
            _acknowledgementButton.onClick.RemoveAllListeners();
            _acknowledgementButton.onClick.AddListener(HideAcknowledgementPopUp);
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
