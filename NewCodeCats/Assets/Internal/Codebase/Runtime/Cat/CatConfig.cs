using UnityEngine;

namespace Internal.Codebase.Runtime.Cat
{
    [CreateAssetMenu(menuName = "StaticData/Create CatConfig", fileName = "CatConfig", order = 1)]
    public class CatConfig : ScriptableObject
    {
        [field: SerializeField] public Markers.Cat Cat { get; private set; }
    }
}