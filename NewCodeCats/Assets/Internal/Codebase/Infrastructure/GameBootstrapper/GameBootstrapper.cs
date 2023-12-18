using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Factories.CameraFactory;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using Internal.Codebase.Infrastructure.GameStateMachine.States;
using Internal.Codebase.Infrastructure.Services.LoadingCurtain;
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
        private ICameraFactory cameraFactory;

        [Inject]
        private void Constructor(ISceneLoaderService loaderService, ICurtainService curtainService,
            CurtainConfig curtainConfig, ICatFactory catFactory, ICameraFactory cameraFactory)
        {
            this.cameraFactory = cameraFactory;
            this.catFactory = catFactory;
            this.curtainConfig = curtainConfig;
            this.curtainService = curtainService;
            this.loaderService = loaderService;
        }
        private void Start()
        {
            stateMachine = new GameStateMachine.GameStateMachine(loaderService, curtainService, curtainConfig, catFactory,
                cameraFactory);
            stateMachine.Enter<BootstrapState>();
        }
        
    }
}