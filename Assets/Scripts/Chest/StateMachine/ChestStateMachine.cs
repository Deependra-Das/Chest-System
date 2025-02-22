using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChestSystem.Chest
{
    public class ChestStateMachine
    {
        private IChestState _currentState;
        private Dictionary<ChestStates, IChestState> _states = new Dictionary<ChestStates, IChestState>();

        public ChestStateMachine()
        {
            CreateStates();
        }

        private void CreateStates()
        {
            _states.Add(ChestStates.LOCKED, new LockedState());
            _states.Add(ChestStates.UNLOCKING, new UnlockingState());
            _states.Add(ChestStates.QUEUED, new QueuedState());
            _states.Add(ChestStates.UNLOCKED, new UnlockedState());
            _states.Add(ChestStates.COLLECTED, new CollectedState());

        }
    }
}

