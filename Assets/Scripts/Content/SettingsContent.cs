using UnityEngine;
using UnityEngine.UI;

namespace FallingBalls.Content {
    public class SettingsContent : ContentBase {
        [SerializeField] private MenuContent _menuContent;
        [SerializeField] private Button _backToMenuButton;

        private void Start() {
            _backToMenuButton.onClick.AddListener(OnBackToMenu);
        }

        private void OnBackToMenu() {
            HideContent();
            _menuContent.ShowContent();
        }
    }
}