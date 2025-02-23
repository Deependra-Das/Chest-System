using ChestSystem.Main;
using ChestSystem.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestSystem.Chest;
using ChestSystem.ChestSlot;

namespace ChestSystem.UI
{
    public class UIView : GenericMonoSingleton<UIView>
    {
        [SerializeField] private Button _generateChestsButton;
        [SerializeField] private Button _UndoOptionButton;
        [SerializeField] private Transform _slotContainerTransform;

        public Transform GetSlotContainerTransform { get { return _slotContainerTransform; } private set { } }

        public void Initialize()
        {
            SetListeners();
        }
        public void SetListeners()
        {
            _generateChestsButton.onClick.AddListener(GenerateButtonClicked);
        }
        public void GenerateButtonClicked()
        {
            GameService.Instance.GenerateChest();
        }

    }

}
