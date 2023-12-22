using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    [DisallowMultipleComponent]
    public sealed class ClickState : EntityState
    {
        public override void Enter(CatStateMachine stateMachine)
        {
            Debug.Log("Add 1 coin");
        }
    }
}