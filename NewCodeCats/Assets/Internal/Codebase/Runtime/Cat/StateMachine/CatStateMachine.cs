using System;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Runtime.Cat.StateMachine.States;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine
{
    public class CatStateMachine : MonoBehaviour
    {
        private Dictionary<Type, State> states;
        private State activeState;
        
        private Vector2 screenBounds;
        
        [field: SerializeField] public float RunOffset { get; private set; } = 1;
        [field: SerializeField] public float Speed { get; private set; } = 4;
        [field: SerializeField] public float Offset { get; private set; }
        public UnityEngine.Camera Camera { get; private set; }

        public ICoroutineRunner CoroutineRunner { get; private set; }

        public void Constructor(ICoroutineRunner coroutineRunner, UnityEngine.Camera camera)
        {
            this.Camera = camera;
            CoroutineRunner = coroutineRunner;
            Debug.Log(nameof(CoroutineRunner) + coroutineRunner);
        }
        private void Awake()
        {
            states = new Dictionary<Type, State>
            {
                [typeof(IdleState)] = new IdleState(this),
                [typeof(RunState)] = new RunState(this),
                [typeof(DragState)] = new DragState(this)
            };

            activeState = GetState<RunState>();
        }
        
        private void Start()
        {
            activeState.Enter();
            activeState.Start();
            
            screenBounds = Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                Camera.transform.position.z));
        }

        private void Update()
        {
            activeState.Update();
            Debug.Log(activeState);
            CheckBoundaries();
        }

        private void FixedUpdate()
        {
            activeState.FixedUpdate();
        }

        private void OnMouseDown()
        {
            ChangeToDragState();
        }

        private void OnMouseDrag()
        {
            activeState.OnMouseDrag();
            CheckBoundaries();
        }

        private void OnMouseUp()
        {
            ChangeToRunState();
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
        
        public void ChangeToRunState() => ChangeState<RunState>().Enter();
        public void ChangeToIdleState() => ChangeState<IdleState>().Enter();
        public void ChangeToDragState() => ChangeState<DragState>().Enter();
        
        public void CheckBoundaries()
        {
            float x = Mathf.Clamp(transform.position.x, -screenBounds.x + Offset,
                screenBounds.x - Offset);
            float y = Mathf.Clamp(transform.position.y, -screenBounds.y + Offset,
                screenBounds.y - Offset);
            transform.position = new Vector3(x, y, 0);
        }
    }
}