using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.CatStatsConfig
{
    [CreateAssetMenu(menuName = "StaticData/Create CatStatsConfig", fileName = "CatStatsConfig", order = 4)]
    public class CatStatsConfig : ScriptableObject
    {
        [field: SerializeField] public CatTypes.CatTypes Type { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
        [field: SerializeField] public int Profit { get; private set; }
    }
}