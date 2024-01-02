using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Factories.CameraFactory;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using Internal.Codebase.Infrastructure.Factories.NotificationCoinFactory;
using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.LoadingCurtain;
using Internal.Codebase.Infrastructure.Services.SceneLoader;
using Internal.Codebase.Runtime.CatsSpawner;
using Internal.Codebase.Runtime.NotificationCoinSpawner;
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
        private INotificationCoinFactory notificationCoinFactory;

        public LoadGameSceneState(GameStateMachine stateMachine, ISceneLoaderService sceneLoader,
            ICurtainService curtainService, CurtainConfig curtainConfig, ICatFactory catFactory,
            ICameraService cameraService, ICoroutineRunner coroutineRunner, INotificationCoinFactory notificationCoinFactory)
        {
            this.notificationCoinFactory = notificationCoinFactory;
            this.cameraService = cameraService;
            this.coroutineRunner = coroutineRunner;
            this.curtainConfig = curtainConfig;
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
            this.curtainService = curtainService;
            this.catFactory = catFactory;
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

            CatsSpawner catsSpawner = catFactory.CreateCatsSpawner();
            catsSpawner.Init();

            NotificationCoinSpawner notificationCoinSpawner = notificationCoinFactory.CreateNotificationCoinSpawner();
            notificationCoinSpawner.Init();

            curtainService.ShowCurtain(false);
            stateMachine.Enter<GameLoopState>();
        }

        private void Load()
        {
            curtainService.ShowCurtain(true);
        }
    }
}