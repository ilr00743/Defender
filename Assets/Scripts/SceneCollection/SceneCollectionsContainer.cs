using UnityEngine;

namespace FallingBalls.SceneCollection
{
    [CreateAssetMenu(fileName = "SceneCollectionsContainer", menuName = "Scenes/SceneCollectionsContainer", order = 0)]
    public class SceneCollectionsContainer : ScriptableObject
    {
        [SerializeField] private SceneCollection[] _sceneCollections;
        private SceneCollection _previousCollection;

        public bool TryGetValue(string sceneKey, out SceneCollection sceneCollection)
        {
            sceneCollection = _previousCollection;
            foreach (var collection in _sceneCollections)
            {
                if (collection.GetCollectionKey().Equals(sceneKey))
                {
                    sceneCollection = collection;
                    _previousCollection = collection;
                    return true;
                }
            }

            return false;
        }
    }
}