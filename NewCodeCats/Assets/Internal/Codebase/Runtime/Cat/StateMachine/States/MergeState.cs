using System;
using ModestTree;
using NTC.Pool;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    [DisallowMultipleComponent]
    public sealed class MergeState : EntityState
    {
        public static event Action<CatTypes.CatTypes, Vector3> OnMerged;
        public override void Enter(CatStateMachine stateMachine)
        {
            OnMerged?.Invoke(stateMachine.Cat.Type);
            NightPool.Despawn(stateMachine.CollisionCat);
            NightPool.Despawn(gameObject);
        }
    }
}