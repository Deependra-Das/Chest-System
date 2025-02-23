using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.ChestSlot
{
    public class ChestSlotView : MonoBehaviour
    { 
        [SerializeField] private GameObject _emptySlotToggle;

        private ChestSlotController _chestSlotController;

        public void SetController(ChestSlotController controller)
        {
            _chestSlotController = controller;
            InitializeChestSlotView();
        }

        public void InitializeChestSlotView()
        {
            ToggleEmptySlotUI(true);
        }

        public void ToggleEmptySlotUI(bool value)
        {
            _emptySlotToggle.gameObject.SetActive(value);
        }
  
    }
}
