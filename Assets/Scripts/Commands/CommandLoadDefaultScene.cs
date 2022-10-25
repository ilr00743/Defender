using FallingBalls.Constants;
using FallingBalls.Signals;
using UnityEngine.SceneManagement;
using Zenject;

namespace FallingBalls.Commands {
    public class CommandLoadDefaultScene : ICommand {
        [Inject] private SignalBus _signalBus;
        
        public void Execute() {
            if (SceneManager.sceneCount == 1) {
                _signalBus.Fire(new SignalSceneLoad(Constant.SceneNames.Menu));
            }
        }
    }
}