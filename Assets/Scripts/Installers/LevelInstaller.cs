using FallingBalls.Signals;
using Zenject;

namespace FallingBalls.Installers {
    public class LevelInstaller : MonoInstaller {
        public override void Start() {
            base.Start();
            Container.Resolve<SignalBus>().Fire(new SignalSceneLoaded(gameObject.scene.name));
        }

        public override void InstallBindings() {
            
        }
    }
}