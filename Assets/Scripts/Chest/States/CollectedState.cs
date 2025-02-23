namespace ChestSystem.Chest
{
    public class CollectedState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public CollectedState(ChestStateMachine stateMachine)
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
