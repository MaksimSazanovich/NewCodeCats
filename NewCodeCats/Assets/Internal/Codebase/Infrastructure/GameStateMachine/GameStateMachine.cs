using System;
using System.Collections.Generic;
using Internal.Codebase.Infrastructure.Factories.CameraFactory;
using Internal.Codebase.Infrastructure.Factories.CatsFactory;
using Internal.Codebase.Infrastructure.Factories.NotificationCoinFactory;
using Internal.Codebase.Infrastructure.GameStateMachine.States;
using Internal.Codebase.Infrastructure.Services.CameraService;
using Internal.Codebase.Infrastructure.Services.CoroutineRunner;
using Internal.Codebase.Infrastructure.Services.LoadingCurtain;
using Internal.Codebase.Infrastructure.Services.SceneLoader;
using Internal.Codebase.UI.MainUI.LoadingCurtain;

namespace Internal.Codebase.Infrastructure.GameStateMachine
{
    public sealed class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> states;
        private IExitableState activeState;

        public GameStateMachine(ISceneLoaderService sceneLoader, ICurtainService curtain, CurtainConfig curtainConfig,
            ICatFactory catFactory, ICameraService cameraService, ICoroutineRunner coroutineRunner,
            INotificationCoinFactory notificationCoinFactory)
        {
            states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
                [typeof(LoadGameSceneState)] = new LoadGameSceneState(this, sceneLoader, curtain, curtainConfig,
                    catFactory, cameraService, coroutineRunner, notificationCoinFactory),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            activeState?.Exit();

            TState state = GetState<TState>();
            activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState
            => states[typeof(TState)] as TState;
    }
}