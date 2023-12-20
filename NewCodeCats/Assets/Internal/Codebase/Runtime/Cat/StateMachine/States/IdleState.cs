using System.Collections;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public class IdleState : State
    {
        private CatStateMachine stateMachine;
        private Coroutine coroutine;

        public override void Enter(CatStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            coroutine = StartCoroutine(MoneyCreatingTimer());
        }

        private IEnumerator MoneyCreatingTimer()
        {
            yield return new WaitForSeconds(1);
            CreateMoney();
            stateMachine.ChangeToRunState();
        }

        private void CreateMoney()
        {
            Debug.Log("+1");
        }

        public override void Exit(CatStateMachine stateMachine)
        {
            StopCoroutine(coroutine);
        }
    }
}