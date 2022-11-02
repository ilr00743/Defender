using FallingBalls.Content;
using FallingBalls.Signals;
using UnityEngine;
using Zenject;

namespace FallingBalls.Installers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private MenuContent _menuContent;

        public override void Start()
        {
            base.Start();
            Container.Resolve<SignalBus>().Fire(new SignalSceneLoaded(gameObject.scene.name));
        }

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MenuContent>().FromInstance(_menuContent).AsSingle();
        }
    }
}