using ChestSystem.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.RefundGem
{
    public class RefundGemService
    {
        private UndoGemUnlockView _undoGemUnlockView;
        private UndoOptionView _undoOptionPrefab;

        private List<UndoOptionView> optionList = new List<UndoOptionView> ();

        public RefundGemService(UndoGemUnlockView undoGemUnlockPrefab, UndoOptionView undoOptionPrefab,Transform canvasTransform)
        {
            _undoGemUnlockView = undoGemUnlockPrefab;
            _undoGemUnlockView = GameObject.Instantiate(undoGemUnlockPrefab, canvasTransform);

            _undoOptionPrefab = undoOptionPrefab;

        }

        public void Initialize()
        {
        
        }

        public void ShowUndoGemUnlockPanel()
        {
            _undoGemUnlockView.ShowUndoGemUnlockPanel();
        }

    }

}
