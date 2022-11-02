using System;
using System.Collections.Generic;
using FallingBalls.ObjectPool;
using FallingBalls.UI;
using FallingBalls.Units;
using UnityEngine;

namespace FallingBalls.Game
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private ObjectPoolUnitsController _poolUnits;
        [SerializeField] private Timer _timer;
        [SerializeField] private Score _score;
        private List<Unit> _units;
        private bool _isStarted;
        public event Action<bool> GameStateChanged;

        private void Start()
        {
            _units = new List<Unit>();
            _isStarted = true;
            _poolUnits.CharacterSpawned += OnCharacterSpawned;
        }

        public void StartGame()
        {
            GameStateChanged?.Invoke(_isStarted);
            _timer.Launch();
            _score.Reset();
            _poolUnits.StartSpawn();
        }

        public void StopGame()
        {
            GameStateChanged?.Invoke(!_isStarted);
            _timer.Stop();
            _poolUnits.StopSpawn();
            DestroyUnits();
        }

        private void OnCharacterSpawned(Unit unit)
        {
            _units.Add(unit);
            unit.Died += OnUnitDied;
        }

        private void OnUnitDied(int damage)
        {
            _score.AddScore(damage);
        }

        private void DestroyUnits()
        {
            foreach (var warrior in _units)
            {
                Destroy(warrior.gameObject);
            }

            _units.Clear();
        }
    }
}