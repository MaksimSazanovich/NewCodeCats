using UnityEngine;

namespace Internal.Codebase.Runtime.NotificationCoinSpawner
{
    [CreateAssetMenu(menuName = "StaticData/Create NotificationCoinSpawnerConfig", fileName = "NotificationCoinSpawnerConfig", order = 6)]
    public class NotificationCoinsSpawnerConfig : ScriptableObject
    {
        [field: SerializeField] public NotificationCoinSpawner NotificationCoinSpawner { get; private set; }
    }
}