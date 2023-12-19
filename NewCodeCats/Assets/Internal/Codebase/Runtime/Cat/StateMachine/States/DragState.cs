using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public sealed class DragState : State
    {
        private Vector2 difference = Vector2.zero;
        
        public DragState(CatStateMachine stateMachine) : base(stateMachine)
        {
            
        }

        public override void Enter()
        {
            StateMachine.transform.position = StateMachine.Camera.ScreenToWorldPoint(Input.mousePosition);
            difference = StateMachine.Camera.ScreenToWorldPoint(Input.mousePosition) - StateMachine.transform.position;
        }
        
        public override void OnMouseDrag()
        {
            StateMachine.transform.position = (Vector2)StateMachine.Camera.ScreenToWorldPoint(Input.mousePosition) - difference;
        }
    }
}