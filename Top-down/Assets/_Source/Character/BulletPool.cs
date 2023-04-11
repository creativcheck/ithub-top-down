using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class BulletPool<T> where T : MonoBehaviour
    {
        private T _prefab;
        private bool _autoExpand;
        private Transform _container;
        private List<T> _pool;

        public BulletPool(T prefab, bool autoExpand, Transform container, int count)
        {
            _prefab = prefab;
            _autoExpand = autoExpand;
            _container = container;

            CreatePool(count);
        }

        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }

        private T CreateObject(bool isActiveByDefault = false)
        {
            T createdObject = GameObject.Instantiate(_prefab, _container);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);

            return createdObject;
        }
    }
}

