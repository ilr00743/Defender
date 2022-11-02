using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace FallingBalls.Units
{
    public class Unit : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private int _maxSpeed;
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _tookDamage;
        [SerializeField] private UnitAnimation _unitAnimation;
        [SerializeField] private Image _clickableZone;
        private IObjectPool<Unit> _pool;
        private int _currentSpeed;
        private int _currentHealth;

        public event Action<int> Died;
        public RectTransform RectTransform { get; private set; }

        private void Awake()
        {
            RectTransform = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            _unitAnimation.Died += BecameInvisible;
        }

        private void OnDisable()
        {
            _unitAnimation.Died -= BecameInvisible;
        }

        private void Start()
        {
            ResetProperties();
        }

        public void SetPosition(Vector2 position)
        {
            RectTransform.anchoredPosition = position;
        }

        public void SetPool(IObjectPool<Unit> pool)
        {
            _pool = pool;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            RectTransform.anchoredPosition += Vector2.down * (_currentSpeed * Time.deltaTime);
        }

        public void BecameInvisible()
        {
            _pool?.Release(this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            TakeDamage(_tookDamage);
        }

        public void ResetProperties()
        {
            _currentSpeed = _maxSpeed;
            _currentHealth = _maxHealth;
            _unitAnimation.SetLifeStatus(true);
            _clickableZone.raycastTarget = true;
        }

        private void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth <= 0)
            {
                Dying();
            }
            _unitAnimation.Hurt();
        }

        private void Dying()
        {
            RectTransform.SetSiblingIndex(0);
            _currentSpeed = 0;
            _unitAnimation.SetLifeStatus(false);
            _clickableZone.raycastTarget = false;
            Died?.Invoke(_maxHealth);
        }
    }
}