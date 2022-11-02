namespace FallingBalls.Signals
{
    public class SignalSceneLoaded
    {
        public readonly string SceneName;

        public SignalSceneLoaded(string sceneName)
        {
            SceneName = sceneName;
        }
    }
}