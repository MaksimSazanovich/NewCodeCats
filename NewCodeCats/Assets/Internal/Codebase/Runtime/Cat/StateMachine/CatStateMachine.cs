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
        
        
        [field: SerializeField] public float Offset { get; private set; }
        public UnityEngine.Camera Camera { get; private set; }

        public ICoroutineRunner CoroutineRunner { get; private set; }

        [SerializeField] private IdleState idleState;
        [SerializeField] private RunState runState;
        [SerializeField] private DragState dragState;

        public void Constructor(ICoroutineRunner coroutineRunner, UnityEngine.Camera camera)
        {
            this.Camera = camera;
            CoroutineRunner = coroutineRunner;
        }
        private void Awake()
        {
            activeState = runState;
        }
        
        private void Start()
        {
            
            activeState.Enter(this);
            activeState.StartState(this);
            
            screenBounds = Camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,
                Camera.transform.position.z));
        }

        private void Update()
        {
            activeState.UpdateState(this);
            CheckBoundaries();
        }

        private void FixedUpdate()
        {
            activeState.FixedUpdateState(this);
        }

        private void OnMouseDown()
        {
            ChangeToDragState();
        }

        private void OnMouseDrag()
        {
            activeState.OnMouseDragState(this);
            CheckBoundaries();
        }

        private void OnMouseUp()
        {
            Debug.Log("MouseUp");
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
            activeState?.Exit(this);

            TState state = GetState<TState>();
            activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : State
            => states[typeof(TState)] as TState;

        public void ChangeToRunState()
        {
            activeState?.Exit(this);
            activeState = runState;
            activeState.Enter(this);
        }

        public void ChangeToIdleState()
        {
            activeState?.Exit(this);
            activeState = idleState;
            activeState.Enter(this);
        }

        public void ChangeToDragState()
        {
            activeState?.Exit(this);
            activeState = dragState;
            activeState.Enter(this);
        }

        /*public void ChangeToRunState() => ChangeState<RunState>().Enter(this);
        public void ChangeToIdleState() => ChangeState<IdleState>().Enter(this);
        public void ChangeToDragState() => ChangeState<DragState>().Enter(this);*/
        
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