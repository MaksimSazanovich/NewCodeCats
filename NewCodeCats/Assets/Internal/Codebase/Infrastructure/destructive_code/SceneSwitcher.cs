using System;
using Internal.Codebase.Infrastructure.Services.SceneLoader;
using Zenject;

namespace destructive_code
{
    public class SceneSwitcher : ITickable
    {
        public Scene CurrentScene { get; private set; }
 
        public event Action<Scene, Scene> OnSceneLoaded; //prev/new 
        private DiContainer container;
        private ISceneLoaderService loaderService;

        public SceneSwitcher(DiContainer container, ISceneLoaderService loaderService)
        {
            this.container = container;
            this.loaderService = loaderService;
        }

        public void PushScene<TScene>(TScene scene)
            where TScene : Scene
        {
            CurrentScene?.OnExit();
            
            container.Inject(scene);
            
            loaderService.LoadScene(scene.GetSceneName(), () => CompletePushing(scene));
        }

        private void CompletePushing<TScene>(TScene scene) 
            where TScene : Scene
        {
            scene.OnLoaded();
         
            OnSceneLoaded?.Invoke(CurrentScene, scene);
            CurrentScene = scene;
        }

        public void Tick()
        {
            CurrentScene?.OnUpdate();
        }
    }
}