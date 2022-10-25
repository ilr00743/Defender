using FallingBalls.Constants;
using FallingBalls.Signals;
using UnityEngine;
using UnityEngine.UI;

namespace FallingBalls.Content {
    public class MainMenuController : ContentBase {
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _settingsButton;
        [SerializeField] private Button _statisticsButton;
        [SerializeField] private MenuContent _menuContent;
        [SerializeField] private SettingsContent _settingsContent;
        [SerializeField] private StatisticsContent _statisticsContent;

        private void Start() {
            _startButton.onClick.AddListener(OnStartClick);
            _settingsButton.onClick.AddListener(OnSettingsClick);
            _statisticsButton.onClick.AddListener(OnStatisticsClick);
            
            _menuContent.ShowContent();
            _settingsContent.HideContent();
            _statisticsContent.HideContent();
        }

        private void OnStartClick() {
            SignalBus.Fire(new SignalSceneLoad(Constant.SceneNames.Game));
        }

        private void OnSettingsClick() {
            _menuContent.HideContent();
            _settingsContent.ShowContent();
        }

        private void OnStatisticsClick() {
            _menuContent.HideContent();
            _statisticsContent.ShowContent();
        }
    }
}