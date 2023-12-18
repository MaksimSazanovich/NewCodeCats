using Internal.Codebase.Runtime.Cat.Components;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.Markers
{
    [DisallowMultipleComponent]
    public sealed class Cat : MonoBehaviour
    {
        [field: SerializeField] public DragComponent DragComponent { get; private set; }
    }
}