using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public class IdleState : State
    {
        public IdleState(CatStateMachine stateMachine) : base(stateMachine)
        {
            
        }
        public override void Enter()
        {
            Debug.Log("Enter IdleState");
        }

        public override void Exit()
        {
            Debug.Log("Exit IdleState");
        }

        public override void Update()
        {
            //Debug.Log("Update IdleState");
        }

        public override void OnCollisionEnter2D(Collision2D other)
        {
        }
    }
}