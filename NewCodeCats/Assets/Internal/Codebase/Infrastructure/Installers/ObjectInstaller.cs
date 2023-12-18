using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.Installers
{
    [DisallowMultipleComponent]
    public sealed class ObjectInstaller : MonoInstaller
    {
        [SerializeField] private Camera camera;
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(camera).AsSingle();
        }
    }
}