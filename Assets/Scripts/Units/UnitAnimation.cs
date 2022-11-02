using System;
using UnityEngine;

namespace FallingBalls.Units
{
    public class UnitAnimation : MonoBehaviour
    {
        private Animator _animator;
        public event Action Died;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnDied()
        {
            Died?.Invoke();
        }
        
        public void SetLifeStatus(bool isAlive)
        {
            _animator.SetBool(AnimatorState.IsAlive, isAlive);
        }

        public void Hurt()
        {
            _animator.SetTrigger(AnimatorState.Hurt);
        }
    }
    
    internal static class AnimatorState
    {
        public static readonly int Hurt = Animator.StringToHash("Hurt");
        public static readonly int IsAlive = Animator.StringToHash("IsAlive");
    }
}
