using System.Collections;
using UnityEngine;

public class BulletMovementController : MonoBehaviour
{
    [SerializeField] [Range(-1, 1)] private int direction;
    [SerializeField] [Range(0, 50)] private float movementSpeed;
    [SerializeField] [Range(0, 1)] private float decelerationValue;
    [SerializeField] private float destructionPoint;
    [SerializeField] private int enemyLayer;
    private Transform _transform;
    private bool _isFiring, _isDestroyed;
    private float _tempSpeed;

    private void Awake()
    {
        _transform = transform;
        _tempSpeed = movementSpeed;
    }

    public void Fire()
    {
        _isFiring = true;
        _isDestroyed = false;
        StartCoroutine(FireBullet());
    }

    private IEnumerator FireBullet()
    {
        while (_transform.position.y*direction<destructionPoint*direction&&_isFiring&&!_isDestroyed)
        {
            _transform.position += Vector3.up * direction * (_tempSpeed -= decelerationValue) * Time.deltaTime;
            yield return null;
        }
        _tempSpeed = movementSpeed;
        gameObject.SetActive(false);
        _isFiring = false;
    }

    private void OnTriggerEnter2D(Component other)
    {
        if(!other.gameObject.layer.Equals(enemyLayer))return;
        ExplosionAnimationSpawner.Instance.SpawnExplosionAnimation(_transform.position);
        _isDestroyed = true;
    }
    
    
}
