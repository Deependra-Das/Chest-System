namespace ChestSystem.Chest
{
    public class UnlockedState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public UnlockedState(ChestStateMachine stateMachine)
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
