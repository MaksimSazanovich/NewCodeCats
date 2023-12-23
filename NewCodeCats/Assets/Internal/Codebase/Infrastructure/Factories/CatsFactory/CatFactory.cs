using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using Internal.Codebase.Runtime.Cat.CatStatsConfig;
using Internal.Codebase.Runtime.Cat.CatTypes;
using Internal.Codebase.Runtime.Cat.Markers;
using Internal.Codebase.Runtime.CatsSpawner;
using NTC.Pool;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Factories.CatsFactory
{
    class CatFactory : ICatFactory
    {
        private IResourceProvider resourceProvider;

        [Inject]
        private void Constructor(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }
        
        public Cat CreateCat(ICoroutineRunner coroutineRunner, Transform at, ICameraService cameraService,
            CatTypes catType)
        {
            var config = resourceProvider.LoadCatConfig();

            var view = NightPool.Spawn(config.Cat, at);
            
            view.StateMachine.Constructor(coroutineRunner, cameraService);
            view.CheckBoundariesComponent.Constructor(cameraService);
            view.Constructor(resourceProvider.LoadCatStatsConfig(catType));

            return view;
        }

        public CatsSpawner CreateCatsSpawner(ICatFactory catFactory, ICoroutineRunner coroutineRunner, ICameraService cameraService)
        {
            var config = resourceProvider.LoadCatsSpawnerConfig();

            var view = Object.Instantiate(config.CatsSpawner);
            view.Constructor(catFactory, coroutineRunner, cameraService);

            return view;
        }
    }
}