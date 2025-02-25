using System.Collections.Generic;
using UnityEngine;
using ChestSystem.Chest;
using ChestSystem.Main;
using ChestSystem.Sound;

namespace ChestSystem.RefundGem
{
    public class RefundGemService
    {
        private UndoGemUnlockView _undoGemUnlockView;
        private UndoOptionPool _undoOptionPool;
        private List<UndoOptionController> optionList = new List<UndoOptionController> ();

        public RefundGemService(UndoGemUnlockView undoGemUnlockPrefab, UndoOptionView undoOptionPrefab,Transform canvasTransform)
        {
            _undoGemUnlockView = GameObject.Instantiate(undoGemUnlockPrefab, canvasTransform);
            _undoOptionPool = new UndoOptionPool(undoOptionPrefab, canvasTransform);
            _undoGemUnlockView.gameObject.SetActive(false);
        }

        public void ShowUndoGemUnlockPanel()
        {
            _undoGemUnlockView.ShowUndoGemUnlockPanel();
            PopulateData();
        }

        private void PopulateData()
        {
            List<ChestController> chestswithUnclockGemCommand=GameService.Instance.GetCommandInvoker().GetUnlockGemRegistryData();

            if(chestswithUnclockGemCommand.Count>0)
            {
                _undoGemUnlockView.ToggleNoDataMessageUI(false);

                foreach (ChestController chest in chestswithUnclockGemCommand)
                {
                    UndoOptionController newOption = _undoOptionPool.GetUndoOption();
                    newOption.Configure(_undoGemUnlockView.GetUndoGemContentTransform());
                    newOption.SetData(chest);
                    optionList.Add(newOption);
                }
            }
            else
            {
                _undoGemUnlockView.ToggleNoDataMessageUI(true);
            }
           
        }

        public void HideUndoGemUnlockPanel()
        {
            GameService.Instance.GetSoundService().PlaySFX(SoundType.ButtonClick);
            UnpopulateData();
            _undoGemUnlockView.HideUndoGemUnlockPanel();
        }

        public void ReturnOptionToPool(UndoOptionController optionToReturn) => _undoOptionPool.ReturnItem(optionToReturn);

        public void UnpopulateData()
        {
            foreach (UndoOptionController option in optionList)
            {
                option.DisableOption();
            }
        }
    }
}
