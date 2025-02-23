using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            _states.Add(ChestStates.LOCKED, new LockedState(_owner,this));
            _states.Add(ChestStates.UNLOCKING, new UnlockingState(_owner,this));
            _states.Add(ChestStates.QUEUED, new QueuedState(_owner,this));
            _states.Add(ChestStates.UNLOCKED, new UnlockedState(_owner,this));
            _states.Add(ChestStates.COLLECTED, new CollectedState(_owner,this));
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

