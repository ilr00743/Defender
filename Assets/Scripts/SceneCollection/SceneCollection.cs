using UnityEditor;
using UnityEngine;

namespace FallingBalls.SceneCollection {
    [CreateAssetMenu(fileName = "SceneCollection", menuName = "Scenes/SceneCollection", order = 1)]
    public class SceneCollection : ScriptableObject, ISceneCollection {
        [SerializeField] private string _collectionKey;
        [SerializeField] private SceneReference _scene;
        [SerializeField] private string _parentCollectionKey;
        
        public string GetSceneName() {
            return _scene;
        }

        public string GetCollectionKey() {
            return _collectionKey;
        }

        public string GetParentCollectionKey() {
            return _parentCollectionKey;
        }
    }
}