using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
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
        private ICoroutineRunner coroutineRunner;

        public void Constructor(ICatFactory catFactory, ICoroutineRunner coroutineRunner, UnityEngine.Camera camera)
        {
            this.coroutineRunner = coroutineRunner;
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
                Cats.Add(catFactory.CreateCat(camera, coroutineRunner, transform));
            }
        }

        [Button(nameof(EnableCat))]
        public void EnableCat()
        {
            catFactory.CreateCat(camera, coroutineRunner, transform);
        }
    }
}