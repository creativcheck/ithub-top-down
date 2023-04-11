using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        [Header("����������� ����������")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;

        [Header("�������� ����������")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _bulletPoolLength;

        [Header("������� �� �����")]
        [SerializeField] private Transform _bulletContainer;
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private Camera _mainCamera;

        [Header("�������")]
        [SerializeField] private Bullet _bulletPrefab;

        [SerializeField] private bool _bulletPoolAutoExpand;

        private CharacterAnimator _characterAnimator;

        private void Awake()
        {
            _characterAnimator = new CharacterAnimator(_animator);

            _inputListener.Initialize(new CharacterActions(_moveSpeed, _rigidbody, _mainCamera, _characterAnimator,
                _bulletPoolLength, _bulletPrefab, _bulletContainer, _bulletPoolAutoExpand));

        }

    }
}

