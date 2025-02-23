using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

namespace ChestSystem.Chest
{
    public class ChestStateMachine
    {
        protected IChestState _currentState;
        protected Dictionary<ChestStates, IChestState> _states = new Dictionary<ChestStates, IChestState>();
        protected ChestController _owner;

        public ChestStateMachine(ChestController Owner)
        {
            _owner = Owner;
            CreateStates();
        }

        private void CreateStates()
        {
            _states.Add(ChestStates.LOCKED, new LockedState(this));
            _states.Add(ChestStates.UNLOCKING, new UnlockingState(this));
            _states.Add(ChestStates.QUEUED, new QueuedState(this));
            _states.Add(ChestStates.UNLOCKED, new UnlockedState(this));
            _states.Add(ChestStates.COLLECTED, new CollectedState(this));
        }

        public void OnChestButtonClick()
        {
            _currentState.OnChestButtonClick();
        }

        public void ChangeState(ChestStates newState) => ChangeState(_states[newState]);

        private void ChangeState(IChestState newState)
        {
            _currentState?.OnStateExit();
            _currentState = newState;
            _currentState.OnStateEnter();
        }

        public ChestStates GetCurrentState()
        {
            foreach (var state in _states)
            {
                if (state.Value == _currentState)
                    return state.Key;
            }

            return ChestStates.LOCKED;
        }
    }
}

