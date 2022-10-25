using UnityEngine;
using Zenject;

namespace FallingBalls.Content {
    public class ContentBase : MonoBehaviour, IInitializable {
        [Inject] protected SignalBus SignalBus;
        private CanvasGroup _canvasGroup;

        protected void Awake() {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public virtual void Initialize() { }

        public void ShowContent() {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
        }

        public void HideContent() {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}