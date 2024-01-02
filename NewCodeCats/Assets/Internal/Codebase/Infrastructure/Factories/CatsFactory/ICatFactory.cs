using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Runtime.Cat.CatTypes;
using Internal.Codebase.Runtime.Cat.Markers;
using Internal.Codebase.Runtime.CatsSpawner;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories.CatsFactory
{
    public interface ICatFactory
    {
        public Cat CreateCat(Transform at, CatTypes catType);
        
        public CatsSpawner CreateCatsSpawner();
    }
}