using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public class RunState : EntityState
    {
        [field: SerializeField] public float RunOffset { get; private set; } = 1;
        [field: SerializeField] public float Speed { get; private set; } = 4;

        private Vector3 randomPostionInSquare;

        private bool canMove = true;

        public override void Enter(CatStateMachine stateMachine)
        {
            canMove = true;
            randomPostionInSquare = GetRandomPostionInSquare();
        }

        public override void FixedUpdateState(CatStateMachine stateMachine)
        {
            if (canMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, randomPostionInSquare,
                    Speed);

                if (transform.position == randomPostionInSquare)
                    stateMachine.ChangeToIdleState();
            }
        }

        public override void Exit(CatStateMachine stateMachine)
        {
            canMove = false;
            DOTween.KillAll();
        }

        private Vector3 GetRandomPostionInSquare()
        {
            return new Vector3(Random.Range(transform.position.x - RunOffset,
                transform.position.x + RunOffset),
                Random.Range(transform.position.y - RunOffset,
                    transform.position.y + RunOffset), 0);
        }
    }
}