using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using Internal.Codebase.Infrastructure.Factories.NotificationCoinFactory;
using Internal.Codebase.Infrastructure.GameStateMachine.States;
using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.LoadingCurtain;
using Internal.Codebase.Infrastructure.Services.NumberAbbreviator;
using Internal.Codebase.Infrastructure.Services.SceneLoader;
using Internal.Codebase.UI.MainUI.LoadingCurtain;
using UnityEngine;
using Zenject;

namespace Internal.Codebase.Infrastructure.GameBootstrapper
{
    public class GameBootstrapper : MonoBehaviour
    {
        private ISceneLoaderService loaderService;
        private ICurtainService curtainService;
        private CurtainConfig curtainConfig;
        private GameStateMachine.GameStateMachine stateMachine;
        private ICatFactory catFactory;
        private ICoroutineRunner coroutineRunner;
        private ICameraService cameraService;
        private INumberAbbreviatorService numberAbbreviatorService;
        private INotificationCoinFactory notificationCoinFactory;

        [Inject]
        private void Constructor(ISceneLoaderService loaderService, ICurtainService curtainService,
            CurtainConfig curtainConfig, ICatFactory catFactory, ICameraService cameraService, ICoroutineRunner coroutineRunner,
            INotificationCoinFactory notificationCoinFactory)
        {
            this.notificationCoinFactory = notificationCoinFactory;
            this.numberAbbreviatorService = numberAbbreviatorService;
            this.cameraService = cameraService;
            this.coroutineRunner = coroutineRunner;
            this.catFactory = catFactory;
            this.curtainConfig = curtainConfig;
            this.curtainService = curtainService;
            this.loaderService = loaderService;
        }
        private void Start()
        {
            stateMachine = new GameStateMachine.GameStateMachine(loaderService, curtainService, curtainConfig, catFactory, 
            cameraService, coroutineRunner, notificationCoinFactory);
            stateMachine.Enter<BootstrapState>();
        }
        
    }
}
