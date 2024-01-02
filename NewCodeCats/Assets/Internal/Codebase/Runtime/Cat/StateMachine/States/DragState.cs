using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public sealed class DragState : EntityState
    {
        private Vector2 difference = Vector2.zero;
        
        public override void OnMouseDragState(CatStateMachine stateMachine)
        {
            transform.position = (Vector2)stateMachine.Camera.ScreenToWorldPoint(Input.mousePosition) - difference;
        }
    }
}