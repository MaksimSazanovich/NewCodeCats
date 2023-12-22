using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.LoadingCurtain;
using Internal.Codebase.Runtime.CatsSpawner;
using UnityEngine;
using Zenject;

namespace destructive_code
{
    public class GameScene : Scene
    {
        private ICurtainService curtainService;
        private ICatFactory catFactory;
        private ICoroutineRunner coroutineRunner;
        private ICameraService cameraService;

        [Inject]
        private void Construct(
            ICurtainService curtainService, ICatFactory catFactory, ICameraService cameraService, 
            ICoroutineRunner coroutineRunner)
        {
            this.cameraService = cameraService;
            this.coroutineRunner = coroutineRunner;
            this.catFactory = catFactory;
            this.curtainService = curtainService;
        }
        
        public override string GetSceneName()
        {
            return SceneName.GameScene;
        }

        public override void OnLoaded()
        {
            cameraService.Init();
            curtainService.Init();
            
            CatsSpawner catsSpawner = catFactory.CreateCatsSpawner(catFactory, coroutineRunner, cameraService);
            catsSpawner.Init();
            
            curtainService.HideCurtain();
        }
        
        public override void OnExit()
        {
        }

        public override void OnUpdate()
        {
        }

    }
}