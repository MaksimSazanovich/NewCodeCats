using System;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Runtime.Cat.CatStatsConfig;
using Internal.Codebase.Runtime.Cat.CatTypes;
using Internal.Codebase.Runtime.Cat.StateMachine.States;
using ModestTree;
using NaughtyAttributes;
using NTC.Pool;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Runtime.CatsSpawner
{
    [DisallowMultipleComponent]
    public sealed class CatsSpawner : MonoBehaviour
    {
        [field: SerializeField] public List<Cat.Markers.Cat> Cats { get; private set; }
        [field: SerializeField] public int MaxCatsCount = 15;

        private CatStatsConfig catStatsConfig;
        private CatTypes catType = CatTypes.Kitten;

        private ICatFactory catFactory;

        private void OnEnable()
        {
            MergeState.OnMerged += CreateUpgradedCat;
        }

        private void OnDisable()
        {
            MergeState.OnMerged -= CreateUpgradedCat;
        }

        private void CreateUpgradedCat(CatTypes type)
        {
            //Debug.Log(type++);
            CreateCat(++type);
        }

        public void Constructor(ICatFactory catFactory)
        {
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
                Cats.Add(catFactory.CreateCat(transform, catType));
            }
        }

        private void CreateCat(CatTypes catType)
        {
            catFactory.CreateCat(transform, catType);
        }

        [Button(nameof(EnableCat))]
        public void EnableCat()
        {
            catFactory.CreateCat(transform,catType);
        }
    }
}