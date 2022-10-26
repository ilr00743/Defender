using FallingBalls.Commands;
using FallingBalls.Content;
using FallingBalls.SceneCollection;
using FallingBalls.Services;
using FallingBalls.Signals;
using UnityEngine;
using Zenject;

namespace FallingBalls.Installers {
    public class SceneInstaller : MonoInstaller {
        [SerializeField] private SceneCollectionsContainer _sceneCollectionsContainer;

        public override void Start() {
            base.Start();
            Container.Resolve<SignalBus>().Fire(new SignalSceneLoaded(gameObject.scene.name));
        }

        public override void InstallBindings() {
            BindSceneLoader();
            BindServices();
            BindSignals();
        }

        private void BindSceneLoader() {
            Container.BindInterfacesAndSelfTo<SceneCollectionsContainer>().FromInstance(_sceneCollectionsContainer)
                .AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<ServiceSceneLoader>().FromNewComponentOnNewGameObject().AsSingle()
                .NonLazy();
        }

        private void BindServices() {
            Container.BindInterfacesAndSelfTo<ServiceTick>().FromNewComponentOnNewGameObject().AsSingle().NonLazy();
        }

        private void BindSignals() {
            SignalBusInstaller.Install(Container);
            
            Container.DeclareSignal<SignalOnApplicationLoaded>();
            Container.BindSignal<SignalOnApplicationLoaded>()
                .ToMethod<CommandLoadDefaultScene>(command => command.Execute).FromNew();

            Container.DeclareSignal<SignalOnLoadingScene>();
            Container.DeclareSignal<SignalSceneLoad>();
            Container.DeclareSignal<SignalSceneLoaded>();
        }
    }
}