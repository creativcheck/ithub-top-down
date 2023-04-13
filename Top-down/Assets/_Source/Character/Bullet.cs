using System.Collections;
using Services;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _lifeTime;

        [SerializeField] private LayerMask _characterLayer;
        [SerializeField] private LayerMask _enemyLayer;

        private void Awake()
        {
            if(_rigidbody == null)
            {
                _rigidbody = GetComponent<Rigidbody2D>();
            }

        }

        private void OnEnable()
        {
            StartCoroutine(Life());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.layer == gameObject.layer 
                || Utils.IsInLayerMask(collision.gameObject.layer, _characterLayer))
            {
                return;
            }
            else if(Utils.IsInLayerMask(collision.gameObject.layer, _enemyLayer))
            {
                if (collision.gameObject.TryGetComponent(out Enemy.Enemy enemy))
                    enemy.TakeDamage(_damage);
            }

            gameObject.SetActive(false);
        }

        private IEnumerator Life()
        {
            _rigidbody.velocity = transform.up * _speed;
            yield return new WaitForSeconds(_lifeTime);

            gameObject.SetActive(false);
        }
    }
}

