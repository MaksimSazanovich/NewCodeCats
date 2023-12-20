using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Factories.CameraFactory;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.LoadingCurtain;
using Internal.Codebase.Infrastructure.Services.SceneLoader;
using Internal.Codebase.Runtime.CatsSpawner;
using Internal.Codebase.UI.MainUI.LoadingCurtain;
using UnityEngine;

namespace Internal.Codebase.Infrastructure.GameStateMachine.States
{
    public sealed class LoadGameSceneState : IPayloadedState<string>
    {
        private readonly GameStateMachine stateMachine;
        private readonly ISceneLoaderService sceneLoader;
        private readonly ICurtainService curtainService;
        private CurtainConfig curtainConfig;
        private ICatFactory catFactory;
        private ICoroutineRunner coroutineRunner;
        private ICameraService cameraService;

        public LoadGameSceneState(GameStateMachine stateMachine, ISceneLoaderService sceneLoader,
            ICurtainService curtainService, CurtainConfig curtainConfig, ICatFactory catFactory,
            ICameraService cameraService, ICoroutineRunner coroutineRunner)
        {
            this.cameraService = cameraService;
            this.coroutineRunner = coroutineRunner;
            this.catFactory = catFactory;
            this.curtainConfig = curtainConfig;
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.curtainService = curtainService;

            this.curtainService.Init();
        }

        public void Enter(string sceneName)
        {
            Load();
            sceneLoader.LoadScene(sceneName, OnLoaded);
        }

        public void Exit() => curtainService.HideCurtain();

        private void OnLoaded()
        {
            cameraService.Init();

            CatsSpawner catsSpawner = catFactory.CreateCatsSpawner(catFactory, coroutineRunner, cameraService);
            catsSpawner.Init();

            curtainService.ShowCurtain(false);
            stateMachine.Enter<GameLoopState>();
        }

        private void Load()
        {
            curtainService.ShowCurtain(true);
        }
    }
}