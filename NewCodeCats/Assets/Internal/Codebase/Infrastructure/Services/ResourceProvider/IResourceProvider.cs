using Internal.Codebase.Runtime.Camera;
using Internal.Codebase.Runtime.Cat;
using Internal.Codebase.Runtime.Cat.CatStatsConfig;
using Internal.Codebase.Runtime.Cat.CatTypes;
using Internal.Codebase.Runtime.CatsSpawner;
using Internal.Codebase.Runtime.NotificationCoinSpawner;
using Internal.Codebase.Runtime.UI.GameUI.NotificationCoin;
using Internal.Codebase.UI.MainUI.LoadingCurtain;

namespace Internal.Codebase.Infrastructure.Services.ResourceProvider
{
    public interface IResourceProvider
    {
        public CurtainConfig LoadCurtainConfig();

        public CatConfig LoadCatConfig();

        public CatsSpawnerConfig LoadCatsSpawnerConfig();

        public CameraConfig LoadCameraConfig();

        public CatStatsConfig LoadCatStatsConfig(CatTypes type);

        public NotificationCoinConfig LoadNotificationCoinConfig();

        public NotificationCoinsSpawnerConfig LoadNotificationCoinSpawnerConfig();
    }
}