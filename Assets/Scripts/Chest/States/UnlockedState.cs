namespace ChestSystem.Chest
{
    public class UnlockedState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public UnlockedState(ChestController Owner, ChestStateMachine stateMachine)
        {
            _owner = Owner;
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            _owner.ToggleUnlockedStateUI(true);
        }

        public void OnChestButtonClick()
        {
            _owner.ChangeState(ChestStates.COLLECTED);
        }

        public void OnStateExit()
        {
            _owner.ToggleUnlockedStateUI(false);
        }
    }

}
