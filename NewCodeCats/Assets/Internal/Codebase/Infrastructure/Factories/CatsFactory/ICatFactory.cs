using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Runtime.Cat.Markers;
using Internal.Codebase.Runtime.CatsSpawner;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories.CatsFactory
{
    public interface ICatFactory
    {
        public Cat CreateCat(Camera camera, ICoroutineRunner coroutineRunner, Transform at, ICameraService cameraService);
        
        public CatsSpawner CreateCatsSpawner(ICatFactory catFactory, ICoroutineRunner coroutineRunner, ICameraService cameraService);
    }
}