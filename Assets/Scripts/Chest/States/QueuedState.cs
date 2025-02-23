namespace ChestSystem.Chest
{
    public class QueuedState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public QueuedState(ChestController Owner, ChestStateMachine stateMachine)
        {
            _owner = Owner;
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            _owner.ToggleQueuedStateUI(true);
        }

        public void Update() { }

        public void OnChestButtonClick()
        {
        }

        public void OnStateExit()
        {
            _owner.ToggleQueuedStateUI(false);
        }
    }

}
