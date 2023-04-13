using PlayerStats;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Character
{
    public class CharacterActions
    {
        private float _moveSpeed;
        private float _shootDelay;
        private int _costOfShoot;
        private Rigidbody2D _rigidbody;
        private Camera _camera;

        private Vector2 _mousePosition, _aimDirection;
        private float _aimAngle;
        private CharacterAnimator _characterAnimator;
        private BulletPool<Bullet> _pool;
        private Ammo _ammo;

        public CharacterActions(float speed, Rigidbody2D rigidbody, Camera camera, CharacterAnimator animator,
            int bulletPoolLength, Bullet bulletPrefab, Transform bulletContainer, bool poolAutoExpand,
            float shootDelay, Ammo ammo, int costOfShoot)
        {
            _moveSpeed = speed;
            _rigidbody = rigidbody;
            _camera = camera;
            _characterAnimator = animator;
            _shootDelay = shootDelay;
            _ammo = ammo;
            _costOfShoot = costOfShoot;

            if (bulletPrefab != null)
                _pool = new BulletPool<Bullet>(bulletPrefab, poolAutoExpand, bulletContainer, bulletPoolLength);
            else
                throw new NullReferenceException("Отсутствует ссылка на префаб пули!");
        }

        public void Move(Vector2 direction)
        {
            _rigidbody.velocity = direction * _moveSpeed;
            _characterAnimator.SetWalk(direction);
        }

        public void Shoot()
        {
            if(_ammo.AmmoAmount > 0)
            {
                _pool.GetFreeElement();
                _ammo.RemoveAmmo(_costOfShoot);
            }
        }

        public IEnumerator ShootDelay()
        {
            while(true)
            {
                Shoot();
                yield return new WaitForSeconds(_shootDelay);
            }
        }

        public void Rotate()
        {
            _mousePosition = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            _aimDirection = _mousePosition - _rigidbody.position;
            _aimAngle = Mathf.Atan2(_aimDirection.y, _aimDirection.x) * Mathf.Rad2Deg;
            _rigidbody.rotation = _aimAngle;
        }

    }

}
