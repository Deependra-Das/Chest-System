using ChestSystem.Main;
using ChestSystem.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ChestSystem.Chest;
using ChestSystem.ChestSlot;
using ChestSystem.Sound;

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
            _UndoOptionButton.onClick.AddListener(UndoOptionButtonClicked);
        }
        public void GenerateButtonClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            GameService.Instance.GenerateChest();
        }

        public void UndoOptionButtonClicked()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            GameService.Instance.GetRefundGemService().ShowUndoGemUnlockPanel();
        }

    }

}
