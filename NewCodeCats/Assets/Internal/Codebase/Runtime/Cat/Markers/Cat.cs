using Internal.Codebase.Runtime.Cat.StateMachine;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.Markers
{
    [DisallowMultipleComponent]
    public sealed class Cat : MonoBehaviour
    {
        [field: SerializeField] public CatStateMachine StateMachine { get; private set; }
    }
}