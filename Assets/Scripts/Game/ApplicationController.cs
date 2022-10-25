using System;
using FallingBalls.Signals;
using UnityEngine;
using Zenject;

namespace FallingBalls.Game {
    public class ApplicationController : MonoBehaviour {
        [Inject] private SignalBus _signalBus;
        
        private void Start() {
            _signalBus.Fire(new SignalOnApplicationLoaded());    
        }
    }
}