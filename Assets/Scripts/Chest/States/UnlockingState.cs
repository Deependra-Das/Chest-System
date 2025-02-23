using static UnityEditor.VersionControl.Asset;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class UnlockingState : IChestState
    {
        public ChestController _owner { get; set; }
        private ChestStateMachine _stateMachine;
        private float timer;

        public UnlockingState(ChestController Owner, ChestStateMachine stateMachine)
        {
            _owner = Owner;
            _stateMachine = stateMachine;
        }

        public void OnStateEnter()
        {
            ResetTimer();
            _owner.ToggleUnlockingStateUI(true);
        }

        public void Update()
        {
            timer -= Time.deltaTime;
            _owner.UpdateUnlockingTimerText(timer/60);

            if (timer <= 0)
            {
                _stateMachine.ChangeState(ChestStates.UNLOCKED);
            }
        }

        public void OnChestButtonClick()
        {
            _owner.ChangeState(ChestStates.UNLOCKED);
        }

        public void OnStateExit()
        {
            _owner.ToggleUnlockingStateUI(false);
            timer = 0;
        }

        private void ResetTimer() => timer = _owner.GetChestModel.UnlockDuration  * 60;
    }

}
