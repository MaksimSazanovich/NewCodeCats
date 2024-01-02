using System;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Factories.NotificationCoinFactory;
using Internal.Codebase.Runtime.Cat.StateMachine.States;
using Internal.Codebase.Runtime.UI.GameUI.NotificationCoin;
using ModestTree;
using NTC.Pool;
using UnityEngine;

namespace Internal.Codebase.Runtime.NotificationCoinSpawner
{
    public sealed class NotificationCoinSpawner : MonoBehaviour
    {
        [field: SerializeField] public List<NotificationCoin> NotificationCoins { get; private set; }
        [field: SerializeField] public int MaxNotificationCoinsCount = 15;

        private INotificationCoinFactory notificationCoinFactory;

        private void OnEnable()
        {
            ClickState.OnCreatedMoneyInClickState += CreateNotificationCoin;
            IdleState.OnCreatedMoneyInIdleState += CreateNotificationCoin;
        }

        private void OnDisable()
        {
            ClickState.OnCreatedMoneyInClickState -= CreateNotificationCoin;
            IdleState.OnCreatedMoneyInIdleState -= CreateNotificationCoin;
        }

        public void Constructor(INotificationCoinFactory notificationCoinFactory)
        {
            this.notificationCoinFactory = notificationCoinFactory;
        }

        public void Init()
        {
            if (NotificationCoins.IsEmpty())
            {
                CreateNotificationCoins();

                DespawnNotificationCoins();
            }
        }

        private void DespawnNotificationCoins()
        {
            for (int i = 0; i < MaxNotificationCoinsCount; i++)
            {
                NightPool.Despawn(NotificationCoins[i]);
            }
        }

        private void CreateNotificationCoins()
        {
            for (int i = 0; i < MaxNotificationCoinsCount; i++)
            {
                NotificationCoins.Add(notificationCoinFactory.CreateNotificationCoin(transform, Vector3.zero, ""));
            }
        }

        private void CreateNotificationCoin(Transform at, float coinOffset, string numberText)
        {
            var position = at.position;
            notificationCoinFactory.CreateNotificationCoin(transform, new Vector3(position.x, position.y + coinOffset, position.z),
                numberText);
        }
    }
}