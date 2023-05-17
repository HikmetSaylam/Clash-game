using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoSingleton<ObjectPool>
{
    public enum ObjectType
    {
        PlayerBullet
        ,EnemyBullet
        ,CircleEnemy
        ,ExplosionAnimation
        ,RightSmallCircleEnemy
        ,LeftSmallCircleEnemy
    }
    [System.Serializable]
    public struct Pool
    {
        public GameObject ObjectPrefab;
        public int PoolSize;
        public Queue<GameObject> PooledObjects;
    }

    [SerializeField] private Pool[] _pools;

    private void Awake()
    {
        for (var i = 0; i < _pools.Length; i++)
        {
            _pools[i].PooledObjects = new Queue<GameObject>();
            for (var j = 0; j < _pools[i].PoolSize; j++)
            {
                var obj = Instantiate(_pools[i].ObjectPrefab);
                obj.SetActive(false);
                _pools[i].PooledObjects.Enqueue(obj);
            }
        }
    }
    
    public GameObject GetGameObject(ObjectType type,Vector3 pos)
    {
        var obj = _pools[(int)type].PooledObjects.Dequeue();
        obj.transform.position = pos;
        _pools[(int)type].PooledObjects.Enqueue(obj);
        obj.SetActive(true);
        return obj;
    }
}