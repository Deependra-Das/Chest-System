using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        [SerializeField] private Button _chestButton;

        private ChestController _chestController;

        public void SetController(ChestController controller)
        {
            _chestController = controller;
            SetListeners();
        }

        private void SetListeners()
        {
            _chestButton.onClick.AddListener(CheckClicked);
        }

        private void CheckClicked()
        {
            Debug.Log(_chestController.GetChestModel.ChestType.ToString());
        }
    }
}
