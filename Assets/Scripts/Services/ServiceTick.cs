using System;
using FallingBalls.Constants;
using FallingBalls.Signals;
using UnityEngine;
using Zenject;

namespace FallingBalls.Services {
    public class ServiceTick : MonoBehaviour {
        public event Action<float> UpdateEvent;

        private void Update() {
            UpdateEvent?.Invoke(Time.deltaTime);
        }
    }
}