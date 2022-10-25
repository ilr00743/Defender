using System.Collections.Generic;
using FallingBalls.Extension;
using FallingBalls.Units;
using UnityEngine;

namespace FallingBalls.Factory {
    [CreateAssetMenu(fileName = "UnitFactory", menuName = "Unit/Factory", order = 0)]
    public class UnitFactory : ScriptableObject {
        [SerializeField] private List<Unit>_units;

        public Unit Create(Vector3 position, Transform container) {
            var unit = Instantiate(_units.RandomItem(), position, Quaternion.identity, container);
            return unit;
        }
    }
}