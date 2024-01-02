using System;
using ModestTree;
using NTC.Pool;
using UnityEngine;
using UnityEngine.UIElements;

namespace Internal.Codebase.Runtime.Cat.StateMachine.States
{
    [DisallowMultipleComponent]
    public sealed class MergeState : EntityState
    {
        public static event Action<CatTypes.CatTypes, Vector3> OnMerged;
        public override void Enter(CatStateMachine stateMachine)
        {
            OnMerged?.Invoke(stateMachine.Cat.Type, GetMiddlePosition(transform.position, 
                stateMachine.CollisionCat.transform.position));
            NightPool.Despawn(stateMachine.CollisionCat);
            NightPool.Despawn(gameObject);
        }

        private Vector3 GetMiddlePosition(Vector3 pointA, Vector3 pointB)
        {
            return (pointA + pointB) / 2f;
        }
    }
}