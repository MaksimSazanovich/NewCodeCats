using Internal.Codebase.Infrastructure.Factories;
using Internal.Codebase.Infrastructure.Factories.CameraFactory;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMainUIFactory>().To<MainUIFactory>().AsSingle().NonLazy();
            Container.Bind<ICatFactory>().To<CatFactory>().AsSingle().NonLazy();
            Container.Bind<ICameraFactory>().To<CameraFactory>().AsSingle().NonLazy();
        }
    }
}