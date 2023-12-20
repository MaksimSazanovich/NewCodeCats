using Internal.Codebase.Infrastructure.Factories.CameraFactory;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Services.CameraService
{
    public sealed class CameraService : ICameraService
    {
        private ICameraFactory cameraFactory;
        private Camera camera;

        [Inject]
        private void Constructor(ICameraFactory cameraFactory) =>
            this.cameraFactory = cameraFactory;

        public void Init() =>
            camera = cameraFactory.CreateCamera();

        public Camera GetCamera() =>
            camera;
    }
}