using Internal.Codebase.Runtime.Camera;
using Internal.Codebase.Runtime.Cat;
using Internal.Codebase.Runtime.CatsSpawner;
using Internal.Codebase.UI.MainUI.LoadingCurtain;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class ConfigInstaller : MonoInstaller
    {
        [SerializeField] private CurtainConfig curtainConfig;
        [SerializeField] private CatConfig catConfig;
        [SerializeField] private CatsSpawnerConfig catsSpawnerConfig;
        [SerializeField] private CameraConfig cameraConfig;

        public override void InstallBindings()
        {
            Container.Bind<CurtainConfig>().FromInstance(curtainConfig).AsSingle();
            Container.Bind<CatConfig>().FromInstance(catConfig).AsSingle();
            Container.Bind<CatsSpawnerConfig>().FromInstance(catsSpawnerConfig).AsSingle();
            Container.Bind<CameraConfig>().FromInstance(cameraConfig).AsSingle();
        }
    }
}