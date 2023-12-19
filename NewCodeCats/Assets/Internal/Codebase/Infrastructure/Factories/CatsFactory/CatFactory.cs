using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.ResourceProvider;
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
        
        public Cat CreateCat(Camera camera, ICoroutineRunner coroutineRunner, Transform at)
        {
            var config = resourceProvider.LoadCatConfig();

            var view = NightPool.Spawn(config.Cat, at);
            
            view.StateMachine.Constructor(coroutineRunner, camera);

            return view;
        }

        public CatsSpawner CreateCatsSpawner(ICatFactory catFactory, ICoroutineRunner coroutineRunner, Camera camera)
        {
            var config = resourceProvider.LoadCatsSpawnerConfig();

            var view = Object.Instantiate(config.CatsSpawner);
            view.Constructor(catFactory, coroutineRunner, camera);

            return view;
        }
    }
}