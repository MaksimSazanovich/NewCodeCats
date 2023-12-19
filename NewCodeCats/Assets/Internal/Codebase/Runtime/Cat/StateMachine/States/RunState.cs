using DG.Tweening;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public class RunState : State
    {
        public RunState(CatStateMachine stateMachine) : base(stateMachine)
        {
            
        }

        public override void Enter()
        {
            StateMachine.transform.DOMove(GetRandomPostionInSquare(),
                StateMachine.Speed).SetSpeedBased().OnComplete(() => StateMachine.ChangeToIdleState());
        }

        public override void Exit()
        {
            DOTween.KillAll();
        }

        private Vector3 GetRandomPostionInSquare()
        {
            return new Vector3(Random.Range(StateMachine.transform.position.x - StateMachine.RunOffset,
                StateMachine.transform.position.x + StateMachine.RunOffset),
                Random.Range(StateMachine.transform.position.y - StateMachine.RunOffset,
                    StateMachine.transform.position.y + StateMachine.RunOffset), 0);
        }
    }
}