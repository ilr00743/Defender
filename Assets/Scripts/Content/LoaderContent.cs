using System;
using FallingBalls.Signals;

namespace FallingBalls.Content {
    public class LoaderContent : ContentBase {
        public override void Initialize() {
            base.Initialize();
            SignalBus.Subscribe<SignalOnApplicationLoaded>(ShowContent);
            SignalBus.Subscribe<SignalOnLoadingScene>(RefreshLoader);
        }

        private void RefreshLoader(SignalOnLoadingScene signal) {
            switch (signal.LoadingType) {
                case LoadingType.None:
                    HideContent();
                    break;
                case LoadingType.Splash:
                    ShowContent();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}