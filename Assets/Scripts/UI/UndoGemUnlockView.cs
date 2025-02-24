using ChestSystem.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ChestSystem.UI
{
    public class UndoGemUnlockView : GenericMonoSingleton<UndoGemUnlockView>
    {
        [SerializeField] private GameObject _UndoGemUnlockContainer;
        [SerializeField] private Transform _UndoGemContentTransform;
        [SerializeField] private Button _closeButton;

        private void Start()
        {
            _closeButton.onClick.AddListener(HideUndoGemUnlockPanel);
        }

        public void ShowUndoGemUnlockPanel()
        {
            _UndoGemUnlockContainer.SetActive(true);
        }

        private void HideUndoGemUnlockPanel()
        {
            _UndoGemUnlockContainer.SetActive(false);
        }

    }

}
