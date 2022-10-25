using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

namespace FallingBalls.Units {
    public class Unit : MonoBehaviour, IPointerClickHandler {
        [SerializeField] private int _speed;
        [SerializeField] private int _tookDamage;
        private IObjectPool<Unit> _pool;
        public event Action<int> Hit;
        public RectTransform RectTransform { get; private set; }

        private void Awake() {
            RectTransform = GetComponent<RectTransform>();
        }

        public void SetPosition(Vector2 position) {
            RectTransform.anchoredPosition = position;
        }

        public void SetPool(IObjectPool<Unit> pool) {
            _pool = pool;
        }

        private void Update() {
            RectTransform.anchoredPosition += Vector2.down * (_speed * Time.deltaTime);
        }

        public void BecameInvisible() {
            _pool?.Release(this);
        }

        public void OnPointerClick(PointerEventData eventData) {
            Hit?.Invoke(_tookDamage);
            BecameInvisible();
        }
    }
}