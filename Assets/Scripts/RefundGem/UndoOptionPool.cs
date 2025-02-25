using UnityEngine;
using ChestSystem.Utilities;

namespace ChestSystem.RefundGem
{
    public class UndoOptionPool : GenericObjectPool<UndoOptionController>
    {
        private UndoOptionView _undoOptionPrefab;
        private Transform _canvasTransform;

        public UndoOptionPool(UndoOptionView undoOptionPrefab, Transform canvasTransform)
        {
            _undoOptionPrefab = undoOptionPrefab;
            _canvasTransform = canvasTransform;
        }

        public UndoOptionController GetUndoOption() => GetItem<UndoOptionController>();

        protected override UndoOptionController CreateItem<T>() => new UndoOptionController(_undoOptionPrefab, _canvasTransform);
    }
}
