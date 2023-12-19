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
        
        public Cat CreateCat(Camera camera, Transform at)
        {
            var config = resourceProvider.LoadCatConfig();

            var view = NightPool.Spawn(config.Cat, at);
            
            view.DragComponent.Constructor(camera);

            return view;
        }

        public CatsSpawner CreateCatsSpawner(ICatFactory catFactory, Camera camera)
        {
            var config = resourceProvider.LoadCatsSpawnerConfig();

            var view = Object.Instantiate(config.CatsSpawner);
            view.Constructor(catFactory, camera);

            return view;
        }
    }
}