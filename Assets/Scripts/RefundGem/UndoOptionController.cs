using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Main;
using ChestSystem.Chest;

namespace ChestSystem.RefundGem
{
    public class UndoOptionController
    {
        private UndoOptionView _undoOptionView;

        public UndoOptionController(UndoOptionView undoOptionPrefab, Transform canvasTransform)
        {
            _undoOptionView = GameObject.Instantiate(undoOptionPrefab, canvasTransform);
            _undoOptionView.SetController(this);
        }

        public void Configure(Transform undoContentTransform)
        {
            _undoOptionView.gameObject.transform.SetParent(undoContentTransform);
            _undoOptionView.gameObject.transform.localPosition = Vector3.zero;
            _undoOptionView.gameObject.transform.localScale = new Vector3(1, 1, 1);
            _undoOptionView.gameObject.SetActive(true);
        }

        public void SetData(ChestController chest)
        {
            _undoOptionView.SetData(chest);
        }

        public void DisableOption()
        {
            _undoOptionView.gameObject.SetActive(false);
            GameService.Instance.GetRefundGemService().ReturnOptionToPool(this);
        }

    }
}
