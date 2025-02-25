using ChestSystem.Main;
using ChestSystem.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.RefundGem
{
    public class UndoGemUnlockView : MonoBehaviour
    {
        [SerializeField] private GameObject _UndoGemUnlockContainer;
        [SerializeField] private Transform _UndoGemContentTransform;
        [SerializeField] private GameObject _noDataMessageToggle;
        [SerializeField] private Button _closeButton;

        private void Start()
        {
            _closeButton.onClick.AddListener(GameService.Instance.GetRefundGemService().HideUndoGemUnlockPanel);
        }

        public void ShowUndoGemUnlockPanel()
        {
            _UndoGemUnlockContainer.SetActive(true);
        }

        public void HideUndoGemUnlockPanel()
        {
            _UndoGemUnlockContainer.SetActive(false);
        }

        public Transform GetUndoGemContentTransform()
        {
            return _UndoGemContentTransform;
        }

        public void ToggleNoDataMessageUI(bool value)
        {
            _noDataMessageToggle.gameObject.SetActive(value);
        }
    }

}
