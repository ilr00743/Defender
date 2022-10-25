using System;
using System.Collections;
using FallingBalls.Factory;
using FallingBalls.Units;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace FallingBalls.ObjectPool {
    public class ObjectPoolUnitsController : MonoBehaviour {
        [SerializeField] private UnitFactory _unitFactory;
        [SerializeField] private RectTransform _spawnZone;
        [SerializeField] private Transform _container, _containerPool;
        [SerializeField] private float _spawnInterval;
        [SerializeField] private float _padding;
        private IObjectPool<Unit> _pool;
        private IEnumerator _coroutine;
        private Transform _transform;
        public event Action<Unit> CharacterSpawned;

        private void Start() {
            _pool = new ObjectPool<Unit>(CreateCharacter, OnGetCharacter, OnReleaseCharacter);
            _transform = GetComponent<Transform>();
            _coroutine = SpawnAfterSeconds();
        }

        private Unit CreateCharacter() {
            var unit = _unitFactory.Create(GetRandomPosition(), _container);
            unit.SetPool(_pool);
            CharacterSpawned?.Invoke(unit);
            return unit;
        }

        private void OnGetCharacter(Unit unit) {
            unit.RectTransform.SetParent(_container);
            unit.RectTransform.SetSiblingIndex(0);
            unit.gameObject.SetActive(true);
        }

        private void OnReleaseCharacter(Unit unit) {
            unit.RectTransform.SetParent(_containerPool);
            unit.gameObject.SetActive(false);
        }

        private void GetUnit(Vector2 position) {
            var unit = _pool?.Get();
            if (unit != null) {
                unit.SetPosition(position);
            }
        }

        private IEnumerator SpawnAfterSeconds() {
            var cooldown = new WaitForSeconds(_spawnInterval);
            while (true) {
                GetUnit(GetRandomPosition());
                yield return cooldown;
            }
        }

        private Vector2 GetRandomPosition() {
            var rect = _spawnZone.rect;
            var randomPositionX = Random.Range(rect.position.x + _padding, -rect.position.x - _padding);
            return new Vector2(randomPositionX, _transform.localPosition.y);
        }

        public void StartSpawn() {
            StartCoroutine(_coroutine);
        }

        public void StopSpawn() {
            StopCoroutine(_coroutine);
            _pool.Clear();
        }
    }
}