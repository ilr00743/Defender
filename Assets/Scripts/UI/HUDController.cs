using FallingBalls.Constants;
using FallingBalls.Game;
using FallingBalls.Signals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FallingBalls.UI {
    public class HUDController : MonoBehaviour {
        [Inject] private SignalBus _signalBus;
        [SerializeField] private LevelController _levelController;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _stopButton;
        [SerializeField] private Button _homeButton;

        private void Awake() {
            _startButton.onClick.AddListener(OnStartGame);
            _stopButton.onClick.AddListener(OnStopGame);
            _homeButton.onClick.AddListener(OnBackHome);
            _levelController.GameStateChanged += OnRefreshButtonsInteractable;
        }

        private void OnStartGame() {
            _levelController.StartGame();
        }

        private void OnStopGame() {
            _levelController.StopGame();
        }

        private void OnBackHome() {
            _signalBus.Fire(new SignalSceneLoad(Constant.SceneNames.Menu));
        }

        private void OnRefreshButtonsInteractable(bool isStateChanged) {
            _startButton.gameObject.SetActive(!isStateChanged);
            _stopButton.gameObject.SetActive(isStateChanged);
            _homeButton.interactable = !isStateChanged;
        }
    }
}