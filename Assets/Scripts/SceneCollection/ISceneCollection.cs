namespace FallingBalls.SceneCollection {
    public interface ISceneCollection {
        string GetSceneName();
        string GetCollectionKey();
        string GetParentCollectionKey();
    }
}