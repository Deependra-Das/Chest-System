namespace ChestSystem.Chest
{
    public class QueuedState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public QueuedState(ChestStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {

        }

        public void OnChestButtonClick()
        {

        }

        public void OnStateExit()
        {

        }
    }

}
