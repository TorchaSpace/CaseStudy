using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ObjectPooler<T> where T : Component
    {
        private readonly T _prefab;
        private readonly Transform _parentTransform;
        private Queue<T> _pool = new Queue<T>();

        public ObjectPooler(T prefab, Transform parentTransform = null)
        {
            _prefab = prefab;
            _parentTransform = parentTransform;

            
        }

        public T GetObject()
        {
            if (_pool.Count == 0)
            {
                T obj = Object.Instantiate(_prefab, _parentTransform);
                obj.gameObject.SetActive(false);
                _pool.Enqueue(obj);
            }

            T pooledObject = _pool.Dequeue();
            pooledObject.gameObject.SetActive(true);

            return pooledObject;
        }

        public void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

