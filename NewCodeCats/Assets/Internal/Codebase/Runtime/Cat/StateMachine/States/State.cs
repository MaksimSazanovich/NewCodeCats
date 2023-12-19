using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public abstract class State 
    {
        protected readonly CatStateMachine StateMachine;
        
        protected State(CatStateMachine stateMachine) =>
            StateMachine = stateMachine;
        
        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Awake()
        {
        }

        public virtual void Start()
        {
        }

        public virtual void Update()
        {
        }

        public virtual void LateUpdate()
        {
        }

        public virtual void FixedUpdate()
        {
        }

        public virtual void OnCollisionEnter2D(Collision2D other)
        {
            
        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            
        }
    }
}