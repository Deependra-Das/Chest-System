using ChestSystem.Chest;

namespace ChestSystem.Chest
{
    public class LockedState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;

        public LockedState(ChestStateMachine stateMachine)
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
