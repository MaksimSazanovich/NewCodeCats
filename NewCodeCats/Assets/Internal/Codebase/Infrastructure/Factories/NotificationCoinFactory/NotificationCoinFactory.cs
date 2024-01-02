using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.Runtime.NotificationCoinSpawner;
using Internal.Codebase.Runtime.UI.GameUI.NotificationCoin;
using NTC.Pool;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Factories.NotificationCoinFactory
{
    public sealed class NotificationCoinFactory : INotificationCoinFactory
    {
        private IResourceProvider resourceProvider;
        private INotificationCoinFactory notificationCoinFactory;

        [Inject]
        private void Constructor(IResourceProvider resourceProvider, INotificationCoinFactory notificationCoinFactory)
        {
            this.notificationCoinFactory = notificationCoinFactory;
            this.resourceProvider = resourceProvider;
        }
        public NotificationCoin CreateNotificationCoin(Transform at, Vector3 on, string numberText)
        {
            var config = resourceProvider.LoadNotificationCoinConfig();

            var view = NightPool.Spawn(config.NotificationCoin, on, Quaternion.identity, at);
            view.Init(numberText);
            
            return view;
        }

        public NotificationCoinSpawner CreateNotificationCoinSpawner()
        {
            var config = resourceProvider.LoadNotificationCoinSpawnerConfig();

            var view = Object.Instantiate(config.NotificationCoinSpawner);
            view.Constructor(notificationCoinFactory);

            return view;
        }
    }
}