namespace ChestSystem.Chest
{
    public class UnlockingState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public UnlockingState(ChestStateMachine stateMachine)
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
