using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator
    {
        private readonly int _speedHash = Animator.StringToHash("Speed");

        private readonly Animator _animator;

        public EnemyAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void SetWalk(Vector2 moveVector)
        {
            _animator.SetFloat(_speedHash, Mathf.Abs(moveVector.x) + Mathf.Abs(moveVector.y));
        }
    }

}
