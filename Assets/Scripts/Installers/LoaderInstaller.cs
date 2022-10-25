using FallingBalls.Content;
using UnityEngine;
using Zenject;

namespace FallingBalls.Installers {
    public class LoaderInstaller : MonoInstaller {
        [SerializeField] private LoaderContent _loaderContent;

        public override void InstallBindings() {
            Container.BindInterfacesAndSelfTo<LoaderContent>().FromInstance(_loaderContent).AsSingle().NonLazy();
        }
    }
}