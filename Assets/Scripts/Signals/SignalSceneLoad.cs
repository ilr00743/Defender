namespace FallingBalls.Signals {
    public class SignalSceneLoad {
        public readonly string SceneName;

        public SignalSceneLoad(string sceneName) {
            SceneName = sceneName;
        }
    }
}