using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public abstract class State : MonoBehaviour
    {
        public virtual void Enter(CatStateMachine stateMachine)
        {
        }

        public virtual void Exit(CatStateMachine stateMachine)
        {
        }

        public virtual void AwakeState(CatStateMachine stateMachine)
        {
        }

        public virtual void StartState(CatStateMachine stateMachine)
        {
        }

        public virtual void UpdateState(CatStateMachine stateMachine)
        {
        }

        public virtual void LateUpdateState(CatStateMachine stateMachine)
        {
        }

        public virtual void FixedUpdateState(CatStateMachine stateMachine)
        {
        }

        public virtual void OnCollisionEnter2D(Collision2D other)
        {
            
        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            
        }

        public virtual void OnMouseDragState(CatStateMachine stateMachine)
        {
            
        }
    }
}