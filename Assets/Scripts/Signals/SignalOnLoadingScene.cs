namespace FallingBalls.Signals {
    public class SignalOnLoadingScene {
        public readonly LoadingType LoadingType;

        public SignalOnLoadingScene(LoadingType loadingType) {
            LoadingType = loadingType;
        }
    }
}