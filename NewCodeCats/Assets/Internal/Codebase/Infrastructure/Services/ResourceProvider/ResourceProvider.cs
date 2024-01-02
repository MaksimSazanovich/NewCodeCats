using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Runtime.Camera;
using Internal.Codebase.Runtime.Cat;
using Internal.Codebase.Runtime.Cat.CatStatsConfig;
using Internal.Codebase.Runtime.Cat.CatTypes;
using Internal.Codebase.Runtime.CatsSpawner;
using Internal.Codebase.Runtime.NotificationCoinSpawner;
using Internal.Codebase.Runtime.UI.GameUI.NotificationCoin;
using Internal.Codebase.UI.MainUI.LoadingCurtain;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Services.ResourceProvider
{
    public sealed class ResourceProvider : IResourceProvider
    {
        public CurtainConfig LoadCurtainConfig()
        {
            return Resources.Load<CurtainConfig>(AssetPath.CurtainConfig);
        }

        public CatConfig LoadCatConfig()
        {
            return Resources.Load<CatConfig>(AssetPath.CatConfig);
        }

        public CatsSpawnerConfig LoadCatsSpawnerConfig()
        {
            return Resources.Load<CatsSpawnerConfig>(AssetPath.CatsSpawnerConfig);
        }

        public CameraConfig LoadCameraConfig()
        {
            return Resources.Load<CameraConfig>(AssetPath.CameraConfig);
        }

        public CatStatsConfig LoadCatStatsConfig(CatTypes type)
        {
            return Resources.Load<CatStatsConfig>(AssetPath.CatStatsConfig + type);
        }

        public NotificationCoinConfig LoadNotificationCoinConfig()
        {
            return Resources.Load<NotificationCoinConfig>(AssetPath.NotificationCoinConfig);
        }

        public NotificationCoinsSpawnerConfig LoadNotificationCoinSpawnerConfig()
        {
            return Resources.Load<NotificationCoinsSpawnerConfig>(AssetPath.NotificationCoinsSpawnerConfig);
        }
    }
}