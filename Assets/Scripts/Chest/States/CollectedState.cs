namespace ChestSystem.Chest
{
    public class CollectedState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public CollectedState(ChestController Owner, ChestStateMachine stateMachine)
        {
            _owner = Owner;
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            _owner.ResetSlotAfterCollecting();
            _owner.ChestCollected();
        }
        public void Update() { }

        public void OnChestButtonClick() {}

        public void OnStateExit() {}
    }

}
