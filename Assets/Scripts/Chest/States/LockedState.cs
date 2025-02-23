using ChestSystem.Chest;

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
        }

        public void Update() { }

        public void OnChestButtonClick()
        {
            _owner.ChangeState(ChestStates.QUEUED);
        }

        public void OnStateExit()
        {
            _owner.ToggleLockedStateUI(false);
        }
    }

}
