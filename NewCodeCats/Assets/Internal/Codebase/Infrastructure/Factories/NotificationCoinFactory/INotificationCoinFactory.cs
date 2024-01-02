using Internal.Codebase.Runtime.NotificationCoinSpawner;
using Internal.Codebase.Runtime.UI.GameUI.NotificationCoin;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories.NotificationCoinFactory
{
    public interface INotificationCoinFactory
    {
        public NotificationCoin CreateNotificationCoin(Transform at, Vector3 on, string numberText);

        public NotificationCoinSpawner CreateNotificationCoinSpawner();
    }
}