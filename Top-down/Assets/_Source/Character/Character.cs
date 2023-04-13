using PlayerStats;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {
        [Header("Необходимые компоненты")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;

        [Header("Числовые переменные")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _shootDelay;
        [SerializeField] private int _bulletPoolLength;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private int _costPerShoot;
        [SerializeField] private int _maxHealth;

        [Header("Объекты на сцене")]
        [SerializeField] private Transform _bulletContainer;
        [SerializeField] private InputListener _inputListener;
        [SerializeField] private Camera _mainCamera;

        [Header("Префабы")]
        [SerializeField] private Bullet _bulletPrefab;

        [SerializeField] private bool _bulletPoolAutoExpand;

        private CharacterAnimator _characterAnimator;
        private Ammo _ammo;

        private int _health;

        private void Awake()
        {
            _characterAnimator = new CharacterAnimator(_animator);
            _ammo = new Ammo(_maxAmmo);
            _health = _maxHealth;

            _inputListener.Initialize(new CharacterActions(_moveSpeed, _rigidbody, _mainCamera, _characterAnimator,
                _bulletPoolLength, _bulletPrefab, _bulletContainer, _bulletPoolAutoExpand,
                _shootDelay, _ammo, _costPerShoot));

        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if(_health <= 0)
            {
                _inputListener.Expose();
                SceneController.ReloadLevel();
            }
        }

    }
}

