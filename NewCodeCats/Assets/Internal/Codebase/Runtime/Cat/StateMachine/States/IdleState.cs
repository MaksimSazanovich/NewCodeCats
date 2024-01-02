using System;
using System.Collections;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public class IdleState : EntityState
    {
        private CatStateMachine stateMachine;
        private Coroutine coroutine;
        
        public static event Action<Transform, float, string> OnCreatedMoneyInIdleState;

        public override void Enter(CatStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            coroutine = StartCoroutine(MoneyCreatingTimer());
        }

        private IEnumerator MoneyCreatingTimer()
        {
            yield return new WaitForSeconds(1);
            CreateMoney();
            yield return new WaitForSeconds(1);
            stateMachine.ChangeToRunState();
        }

        private void CreateMoney()
        {
            OnCreatedMoneyInIdleState?.Invoke(transform, stateMachine.Cat.CoinOffset,
                stateMachine.NumberAbbreviatorService.AbbreviateNumber(stateMachine.Cat.Profit) );
        }

        public override void Exit(CatStateMachine stateMachine)
        {
            StopCoroutine(coroutine);
        }
    }
}