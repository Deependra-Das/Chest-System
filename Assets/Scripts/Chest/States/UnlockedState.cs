using ChestSystem.Main;

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
            if(_stateMachine.GetPreviousState() == ChestStates.UNLOCKING)
            {
                _owner.RemoveChestFromUnlockingQueue();
            }
            GameService.Instance.GetSoundService().PlaySFX(Sound.SoundType.ChestUnlocked);
            _owner.ToggleUnlockedStateUI(true);
        }

        public void Update() {}

        public void OnChestButtonClick()
        {
            _stateMachine.ChangeState(ChestStates.COLLECTED);
        }

        public void OnStateExit()
        {
            _owner.ToggleUnlockedStateUI(false);
        }
    }

}
