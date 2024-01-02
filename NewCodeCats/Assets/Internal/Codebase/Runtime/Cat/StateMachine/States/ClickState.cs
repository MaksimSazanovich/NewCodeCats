using System;
using System.Globalization;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    [DisallowMultipleComponent]
    public sealed class ClickState : EntityState
    {
        private CatStateMachine stateMachine;
        public static event Action<Transform, float, string> OnCreatedMoneyInClickState;
        public override void Enter(CatStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            
            OnCreatedMoneyInClickState?.Invoke(transform, this.stateMachine.Cat.CoinOffset,
                this.stateMachine.NumberAbbreviatorService.AbbreviateNumber(this.stateMachine.Cat.Profit));
        }
    }
}