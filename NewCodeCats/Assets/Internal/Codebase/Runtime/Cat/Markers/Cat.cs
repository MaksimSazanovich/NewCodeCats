using Internal.Codebase.Runtime.Cat.Components;
using Internal.Codebase.Runtime.Cat.StateMachine;
using UnityEngine;

namespace Internal.Codebase.Runtime.Cat.Markers
{
    [DisallowMultipleComponent]
    public sealed class Cat : MonoBehaviour
    {
        [field: SerializeField] public CatStateMachine StateMachine { get; private set; }
        [field: SerializeField] public CheckBoundariesComponent CheckBoundariesComponent { get; private set; }
        [field: SerializeField] public float CoinOffset { get; private set; }

        [SerializeField] private SpriteRenderer spriteRenderer;
        [field: SerializeField] public CatTypes.CatTypes Type { get; private set; }
        public double Profit { get; private set; }

        public void Constructor(CatStatsConfig.CatStatsConfig config)
        {
            Type = config.Type;
            Profit = config.Profit;
            CoinOffset = config.CoinOffset;
            
            spriteRenderer.sprite = config.Sprite;
        }
    }
}