using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using ModestTree;
using NaughtyAttributes;
using NTC.Pool;
using UnityEngine;

namespace Internal.Codebase.Runtime.CatsSpawner
{
    [DisallowMultipleComponent]
    public sealed class CatsSpawner : MonoBehaviour
    {
        private ICatFactory catFactory;
        [field: SerializeField] public List<Cat.Markers.Cat> Cats { get; private set; }
        [field: SerializeField] public int MaxCatsCount = 15;
        private UnityEngine.Camera camera;

        public void Constructor(ICatFactory catFactory, UnityEngine.Camera camera)
        {
            this.camera = camera;
            this.catFactory = catFactory;
        }

        public void Init()
        {
            if (Cats.IsEmpty())
            {
                CreateCats();

                DespawnCats();
            }
        }

        private void DespawnCats()
        {
            for (int i = 0; i < MaxCatsCount - 1; i++)
            {
                NightPool.Despawn(Cats[i]);
            }
        }

        private void CreateCats()
        {
            for (int i = 0; i < MaxCatsCount; i++)
            {
                Cats.Add(catFactory.CreateCat(camera, transform));
            }
        }
    }
}