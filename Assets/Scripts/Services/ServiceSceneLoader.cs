using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FallingBalls.Content;
using FallingBalls.SceneCollection;
using FallingBalls.Signals;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace FallingBalls.Services
{
    public class ServiceSceneLoader : MonoBehaviour, IInitializable
    {
        private SceneCollectionsContainer _sceneCollectionsContainer;
        private SignalBus _signalBus;

        [Inject]
        private void Constructor(SceneCollectionsContainer sceneCollectionsContainer, SignalBus signalBus)
        {
            _sceneCollectionsContainer = sceneCollectionsContainer;
            _signalBus = signalBus;
        }

        public void Initialize()
        {
            _signalBus.Subscribe<SignalSceneLoad>(LoadScene);
            _signalBus.Subscribe<SignalSceneLoaded>(SceneLoaded);
        }

        private void LoadScene(SignalSceneLoad sceneLoad)
        {
            StartCoroutine(LoadSceneInner(sceneLoad));
        }

        private static void SceneLoaded(SignalSceneLoaded sceneLoaded)
        {
            SetActiveScene(sceneLoaded.SceneName);
        }

        private IEnumerator LoadSceneInner(SignalSceneLoad sceneLoad)
        {
            _signalBus.Fire(new SignalOnLoadingScene(LoadingType.Splash));

            if (_sceneCollectionsContainer.TryGetValue(sceneLoad.SceneName, out var sceneCollection))
            {
                var sceneCollections = new Stack<ISceneCollection>();
                GetParentSceneCollection(sceneCollection, ref sceneCollections);

                foreach (var collection in sceneCollections.ToArray())
                {
                    if (!IsSceneLoaded(collection))
                    {
                        yield return SceneManager.LoadSceneAsync(collection.GetSceneName(), LoadSceneMode.Additive)
                            .isDone;
                    }
                }

                yield return UnloadUnusedSceneInner(sceneCollections.ToArray());
            }

            _signalBus.Fire(new SignalOnLoadingScene(LoadingType.None));
        }

        private static IEnumerator UnloadUnusedSceneInner(ISceneCollection[] collections)
        {
            yield return UnloadScene(SceneManager.GetActiveScene(), collections);

            for (var count = 0; count < SceneManager.sceneCount; count++)
            {
                yield return UnloadScene(SceneManager.GetSceneAt(count), collections);
            }
        }

        private static IEnumerator UnloadScene(Scene unloadScene, ISceneCollection[] collections)
        {
            if (!collections.Any(collection => collection.GetSceneName().Equals(unloadScene.name)))
            {
                SetVisibleContent(unloadScene, false);
                yield return SceneManager.UnloadSceneAsync(unloadScene);
            }
        }

        private static bool IsSceneLoaded(ISceneCollection sceneCollection)
        {
            for (var count = 0; count < SceneManager.sceneCount; count++)
            {
                var scene = SceneManager.GetSceneAt(count);
                if (scene.name.Equals(sceneCollection.GetSceneName()) && scene.isLoaded)
                {
                    return true;
                }
            }

            return false;
        }

        private static void SetActiveScene(string sceneName)
        {
            for (var count = 0; count < SceneManager.sceneCount; count++)
            {
                var scene = SceneManager.GetSceneAt(count);
                if (scene.name.Equals(sceneName) && scene.isLoaded)
                {
                    SetVisibleContent(scene, true);
                    SceneManager.SetActiveScene(scene);
                    break;
                }
            }
        }

        private static void SetVisibleContent(Scene scene, bool isActive)
        {
            var sceneObjects = scene.GetRootGameObjects();

            foreach (var sceneObject in sceneObjects)
            {
                var content = sceneObject.GetComponent<GUIController>();
                if (content != null)
                {
                    if (isActive)
                    {
                        content.ShowContent();
                    }
                    else
                    {
                        content.HideContent();
                    }

                    break;
                }
            }
        }

        private void GetParentSceneCollection(ISceneCollection sceneCollection, ref Stack<ISceneCollection> sceneCollections)
        {
            sceneCollections.Push(sceneCollection);
            var parentCollectionKey = sceneCollection.GetParentCollectionKey();

            if (string.IsNullOrEmpty(parentCollectionKey))
            {
                return;
            }

            if (_sceneCollectionsContainer.TryGetValue(parentCollectionKey, out var parentSceneCollection))
            {
                GetParentSceneCollection(parentSceneCollection, ref sceneCollections);
            }
        }
    }
}