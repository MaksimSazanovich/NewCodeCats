using UnityEngine;

namespace Internal.Codebase.Runtime.CatsSpawner
{
    [CreateAssetMenu(menuName = "StaticData/Create CatsSpawnerConfig", fileName = "CatsSpawnerConfig", order = 2)]
    public class CatsSpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public CatsSpawner CatsSpawner { get; private set; }
    }
}