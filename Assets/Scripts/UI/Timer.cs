using System.Collections;
using FallingBalls.Helper;
using FallingBalls.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace FallingBalls.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class Timer : MonoBehaviour
    {
        [Inject] private ServiceTick _serviceTick;
        private TMP_Text _timerText;
        private IEnumerator _coroutine;
        private float _currentTime;

        private void Awake()
        {
            _timerText = GetComponent<TMP_Text>();
        }

        private void Tick(float time)
        {
            _currentTime += time;
            _timerText.text = TimeHelper.ConvertTotalSecondsToTimer(_currentTime);
        }

        public void Launch()
        {
            _currentTime = 0;
            _serviceTick.UpdateEvent += Tick;
        }

        public void Stop()
        {
            _serviceTick.UpdateEvent -= Tick;
        }
    }
}