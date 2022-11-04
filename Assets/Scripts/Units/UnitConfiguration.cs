using UnityEngine;

namespace FallingBalls.Units
{
    [System.Serializable]
    public class UnitConfiguration
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _tookDamage;
        [SerializeField] private int _maxSpeed;

        public int MaxHealth => _maxHealth;
        public int TookDamage => _tookDamage;
        public int MaxSpeed => _maxSpeed;
    }
}