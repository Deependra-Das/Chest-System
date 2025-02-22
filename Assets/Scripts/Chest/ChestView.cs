using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.Chest
{
    public class ChestView : MonoBehaviour
    {
        [SerializeField] private Button _chestButton;

        private ChestController _chestController;

        private void Awake()
        {
            _chestButton.onClick.AddListener(CheckClicked);
        }

        public void SetController(ChestController controller)
        {
            _chestController = controller;
        }

        private void CheckClicked()
        {
            Debug.Log("Chest Clicked");
        }
    }
}
