using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyActions
    {
        private int _health;
        private float _speed;
        private Rigidbody2D _rigidbody;
        private EnemyAnimator _enemyAnimator;
        private FinishZone _finishZone;
        private Enemy _enemy;
        private Collider2D _enemyCollider;

        public EnemyActions(int health, float speed, Rigidbody2D rigidbody, EnemyAnimator enemyAnimator,
            Enemy enemy, FinishZone finish, Collider2D enemyCollider)
        {
            _health = health;
            _speed = speed;
            _rigidbody = rigidbody;
            _enemyAnimator = enemyAnimator;
            _finishZone = finish;
            _enemy = enemy;

            _finishZone.EnemyCollection.AddEnemy(_enemy);
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if(_health <= 0)
            {
                //_rigidbody.isKinematic = true;
                //_enemyCollider.enabled = false;
                // запускать анимацию смерти
                _finishZone.EnemyCollection.RemoveEnemy(_enemy);
                GameObject.Destroy(_enemy.gameObject);
            }
        }

        public void MoveToCharacter(Transform characterTransform)
        {
            Vector2 direction = (Vector2)characterTransform.position - _rigidbody.position;
            direction.Normalize();
            _rigidbody.velocity = direction * _speed;
            Rotate(direction);
            _enemyAnimator.SetWalk(_rigidbody.velocity);
        }

        public void StopMove()
        {
            _rigidbody.velocity = Vector2.zero;
            _enemyAnimator.SetWalk(_rigidbody.velocity);
        }

        private void Rotate(Vector2 direction)
        {
            float aimAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _rigidbody.rotation = aimAngle + 90;
        }
    }

}