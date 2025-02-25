using ChestSystem.Chest;
using ChestSystem.UI;

namespace ChestSystem.Chest
{
    public class LockedState : IChestState
    {
        private ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public LockedState(ChestController Owner, ChestStateMachine stateMachine)
        {
            _owner = Owner;
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            _owner.ToggleLockedStateUI(true);
            _owner.UpdateGemCost(_owner.GetChestModel.UnlockDuration);
        }

        public void Update() { }

        public void OnChestButtonClick()
        {
            _owner.ShowActionPopUp();
        }

        public void OnStateExit()
        {
            _owner.ToggleLockedStateUI(false);
        }
    }

}
