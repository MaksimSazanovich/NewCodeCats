using Zenject;

namespace destructive_code
{
    public sealed class GameStartPoint : MonoInstaller, IInitializable
    {
        private SceneSwitcher switcher;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneSwitcher>().FromNew().AsSingle();
            Container.BindInterfacesTo<GameStartPoint>().FromInstance(this);
        }

        public void Initialize()
        {
            switcher.PushScene(new GameScene());
        }
    }
}