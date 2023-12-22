namespace destructive_code
{
    public abstract class Scene
    {
        public abstract string GetSceneName();

        public virtual void OnLoaded() {}
        public virtual void OnExit() {}
        public virtual void OnUpdate() {}
    }
}