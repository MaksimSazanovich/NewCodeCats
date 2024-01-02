using UnityEngine;

namespace Internal.Codebase.Runtime.UI.GameUI.NotificationCoin
{
    [CreateAssetMenu(menuName = "StaticData/Create NotificationCoinConfig", fileName = "NotificationCoinConfig", order = 5)]
    public class NotificationCoinConfig : ScriptableObject
    {
        [field: SerializeField] public NotificationCoin NotificationCoin { get; private set; }

        [field: SerializeField] public float Offset { get; private set; }

        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public float FadeSpeed { get; private set; }
    }
}