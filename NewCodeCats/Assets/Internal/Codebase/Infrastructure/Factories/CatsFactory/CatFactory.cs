using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.NumberAbbreviator;
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
        private INumberAbbreviatorService numberAbbreviatorService;
        private ICameraService cameraService;
        private ICoroutineRunner coroutineRunner;
        private ICatFactory catFactory;

        [Inject]
        private void Constructor(IResourceProvider resourceProvider, INumberAbbreviatorService numberAbbreviatorService,
            ICameraService cameraService, ICoroutineRunner coroutineRunner, ICatFactory catFactory)
        {
            this.catFactory = catFactory;
            this.coroutineRunner = coroutineRunner;
            this.cameraService = cameraService;
            this.numberAbbreviatorService = numberAbbreviatorService;
            this.resourceProvider = resourceProvider;
            
        }
        
        public Cat CreateCat(Transform at, CatTypes catType)
        {
            var config = resourceProvider.LoadCatConfig();

            var view = NightPool.Spawn(config.Cat, at);
            
            view.StateMachine.Constructor(coroutineRunner, cameraService, numberAbbreviatorService);
            view.CheckBoundariesComponent.Constructor(cameraService);
            view.Constructor(resourceProvider.LoadCatStatsConfig(catType));

            return view;
        }

        public CatsSpawner CreateCatsSpawner()
        {
            var config = resourceProvider.LoadCatsSpawnerConfig();

            var view = Object.Instantiate(config.CatsSpawner);
            view.Constructor(catFactory);
            
            return view;
        }
    }
}