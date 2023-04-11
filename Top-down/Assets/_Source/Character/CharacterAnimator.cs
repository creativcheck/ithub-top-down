using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class CharacterAnimator
    {
        private readonly int _speedHash = Animator.StringToHash("Speed");

        private Animator _animator;

        public CharacterAnimator(Animator animator)
        {
            _animator = animator;
        }

        public void SetWalk(Vector2 moveVector)
        {
            _animator.SetFloat(_speedHash, Mathf.Abs(moveVector.x) + Mathf.Abs(moveVector.y));
        }

    }
}

