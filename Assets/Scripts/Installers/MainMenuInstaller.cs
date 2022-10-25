using FallingBalls.Content;
using UnityEngine;
using Zenject;

namespace FallingBalls.Installers {
    public class MainMenuInstaller : MonoInstaller {
        [SerializeField] private MenuContent _menuContent;

        public override void InstallBindings() {
            Container.BindInterfacesTo<MenuContent>().FromInstance(_menuContent).AsSingle();
        }
    }
}