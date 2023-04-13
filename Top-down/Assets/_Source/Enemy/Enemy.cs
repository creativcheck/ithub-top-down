using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    [RequireComponent (typeof(Rigidbody2D))]
    public class Enemy : MonoBehaviour
    {
        [Header ("Numeric values")]
        [SerializeField] private float _speed, _timeBetweenDamage;
        [SerializeField] private int _health, _damage;

        [Header("Components")]
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private FinishZone _finishZone;
        [SerializeField] private Collider2D _enemyCollider;

        [Space(20)]
        [SerializeField] private LayerMask _characterLayer;


        private EnemyAnimator _enemyAnimator;
        private EnemyActions _actions;
        private bool canDamage = true;

        void Start()
        {
            _enemyAnimator = new EnemyAnimator(_animator);
            _actions = new EnemyActions(_health, _speed, _rigidbody, _enemyAnimator,
                this, _finishZone, _enemyCollider);

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if(Utils.IsInLayerMask(collision.gameObject.layer, _characterLayer))
            {
                _actions.MoveToCharacter(collision.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (Utils.IsInLayerMask(collision.gameObject.layer, _characterLayer))
            {
                _actions.StopMove();
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (Utils.IsInLayerMask(collision.gameObject.layer, _characterLayer))
            {
                if (canDamage)
                    StartCoroutine(DamageCharacter(collision));
            }
        }

        public IEnumerator DamageCharacter(Collision2D collision)
        {
            canDamage = false;
            if (collision.gameObject.TryGetComponent(out Character.Character character))
                character.TakeDamage(_damage);
            yield return new WaitForSeconds(_timeBetweenDamage);
            canDamage = true;
        }

        public void TakeDamage(int damage)
        {
            _actions.TakeDamage(damage);
        }
    }

}
