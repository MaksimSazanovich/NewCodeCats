using System;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Runtime.Cat.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Runtime.Cat.StateMachine
{
    //[RequireComponent(typeof(NavMeshAgent))]
    public class CatStateMachine : MonoBehaviour
    {
        private Dictionary<Type, State> states;
        private State activeState;
        [field: SerializeField] public ICoroutineRunner CoroutineRunner { get; private set; }

        [field: SerializeField] public float RunOffset { get; private set; } = 1;
        [field: SerializeField] public float Speed { get; private set; } = 4;

        [Inject]
        private void Constructor(ICoroutineRunner coroutineRunner)
        {
            this.CoroutineRunner = coroutineRunner;
            Debug.Log(nameof(this.CoroutineRunner) + coroutineRunner);
        }
        private void Awake()
        {
            states = new Dictionary<Type, State>
            {
                [typeof(IdleState)] = new IdleState(this),
                [typeof(RunState)] = new RunState(this)
            };

            activeState = GetState<RunState>();
        }
        
        private void Start()
        {
            activeState.Enter();
            activeState.Start();
        }

        private void Update()
        {
            activeState.Update();
        }

        private void FixedUpdate()
        {
            activeState.FixedUpdate();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            activeState.OnCollisionEnter2D(other);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            activeState.OnTriggerEnter2D(other);
        }

        public TState ChangeState<TState>() where TState : State
        {
            activeState?.Exit();

            TState state = GetState<TState>();
            activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : State
            => states[typeof(TState)] as TState;
        
        private void ChangeToRunState() => ChangeState<RunState>().Enter();
    }
}