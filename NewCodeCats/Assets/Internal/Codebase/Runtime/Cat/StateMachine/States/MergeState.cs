using System;
using ModestTree;
using NTC.Pool;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    [DisallowMultipleComponent]
    public sealed class MergeState : EntityState
    {
        public static event Action<CatTypes.CatTypes> OnMerged;
        public override void Enter(CatStateMachine stateMachine)
        {
            Debug.Log(nameof(MergeState));
            OnMerged?.Invoke(stateMachine.Cat.Type);
            NightPool.Despawn(gameObject);
            NightPool.Despawn(stateMachine.CollisionCat);
        }
    }
}