using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

namespace Project.Core.StateMachine
{
    public class StateMachine<T> where T : System.Enum
    {
        public Dictionary<T, StateBase> dictionaryState;
        private StateBase _currentState;
        public float timeToStartGame = 1.0f;

        public StateBase CurrentState
        {
            get { return _currentState; }
        }


        public void Init()
        {
            dictionaryState = new Dictionary<T, StateBase>();
        }

        public void RegisterStates(T typeEnmum, StateBase state)
        {
            dictionaryState.Add(typeEnmum, state);
        }


        public void SwitchState(T state)
        {
            if (_currentState != null) _currentState.OnStateExit();
            _currentState = dictionaryState[state];
            _currentState.OnStateEnter();
        }

        public void Update()
        {
            if (_currentState != null) _currentState.OnStateStay();

        }
    }
}
