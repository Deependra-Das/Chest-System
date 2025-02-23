namespace ChestSystem.Chest
{
    public class UnlockingState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public UnlockingState(ChestController Owner, ChestStateMachine stateMachine)
        {
            _owner = Owner;
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            _owner.ToggleUnlockingStateUI(true);
        }

        public void OnChestButtonClick()
        {
            _owner.ChangeState(ChestStates.UNLOCKED);
        }

        public void OnStateExit()
        {
            _owner.ToggleUnlockingStateUI(false);
        }
    }

}
