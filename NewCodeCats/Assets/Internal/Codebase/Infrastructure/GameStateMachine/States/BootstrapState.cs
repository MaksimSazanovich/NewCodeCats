using Internal.Codebase.Infrastructure.Constants;
using Internal.Codebase.Infrastructure.Services.SceneLoader;

namespace Internal.Codebase.Infrastructure.GameStateMachine.States
{
    public sealed class BootstrapState : IState
    {
        private readonly GameStateMachine stateMachine;
        private readonly ISceneLoaderService sceneLoader;

        public BootstrapState(GameStateMachine stateMachine, ISceneLoaderService sceneLoader)
        {
            this.stateMachine = stateMachine;
            this.sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            sceneLoader.LoadScene(SceneName.InitialScene, onLoadedScene: EnterLoadLevel);
        }

        private void EnterLoadLevel() => stateMachine.Enter<LoadGameSceneState, string>(SceneName.GameScene);

        public void Exit()
        {
        }
        
    }
}