using Internal.Codebase.Runtime.Cat.Markers;
using Internal.Codebase.Runtime.CatsSpawner;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.Factories.CatsFactory
{
    public interface ICatFactory
    {
        public Cat CreateCat(Camera camera);
        
        public CatsSpawner CreateCatsSpawner(ICatFactory catFactory, Camera camera);
    }
}