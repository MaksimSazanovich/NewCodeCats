
using System.Collections;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    public class IdleState : State
    {

        public IdleState(CatStateMachine stateMachine) : base(stateMachine)
        {
            
        }
        
        public override void Enter()
        {
            StateMachine.CoroutineRunner.StartCoroutine(MoneyCreatingTimer());
        }

        private IEnumerator MoneyCreatingTimer()
        {
            yield return new WaitForSeconds(1);
            CreateMoney();
            StateMachine.ChangeState<RunState>().Enter();
        }

        private void CreateMoney()
        {
            Debug.Log("+1");
        }
    }
}