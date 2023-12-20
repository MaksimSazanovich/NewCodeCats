using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public sealed class DragState : State
    {
        private Vector2 difference = Vector2.zero;
        
        public override void Enter(CatStateMachine stateMachine)
        {
            transform.position = stateMachine.Camera.ScreenToWorldPoint(Input.mousePosition);
            difference = stateMachine.Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        }
        
        public override void OnMouseDragState(CatStateMachine stateMachine)
        {
            transform.position = (Vector2)stateMachine.Camera.ScreenToWorldPoint(Input.mousePosition) - difference;
        }
    }
}