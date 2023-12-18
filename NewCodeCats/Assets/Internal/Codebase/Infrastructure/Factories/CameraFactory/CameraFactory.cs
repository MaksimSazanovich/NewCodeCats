using Internal.Codebase.Infrastructure.Services.ResourceProvider;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Factories.CameraFactory
{
    class CameraFactory : ICameraFactory
    {
        private IResourceProvider resourceProvider;

        [Inject]
        private void Constructor(IResourceProvider resourceProvider)
        {
            this.resourceProvider = resourceProvider;
        }
        
        public Camera CreateCamera()
        {
            var config = resourceProvider.LoadCameraConfig();

            var view = Object.Instantiate(config.Camera);

            return view;
        }
    }
}