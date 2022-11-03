using UnityEngine;

namespace FallingBalls.SceneCollection
{
    [CreateAssetMenu(fileName = "SceneCollectionsContainer", menuName = "Scenes/SceneCollectionsContainer", order = 0)]
    public class SceneCollectionsContainer : ScriptableObject
    {
        [SerializeField] private SceneCollection[] _sceneCollections;

        public bool TryGetValue(string sceneKey, out SceneCollection sceneCollection)
        {
            sceneCollection = null;
            foreach (var collection in _sceneCollections)
            {
                if (collection.GetCollectionKey().Equals(sceneKey))
                {
                    sceneCollection = collection;
                    return true;
                }
            }

            return false;
        }
    }
}