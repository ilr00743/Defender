using FallingBalls.Units;
using UnityEngine;

namespace FallingBalls.ObjectPool
{
    public class Ground : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private BoxCollider2D _collider;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _collider = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            _collider.size = _rectTransform.rect.size;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out Unit unit))
            {
                unit.BecameInvisible();
            }
        }
    }
}