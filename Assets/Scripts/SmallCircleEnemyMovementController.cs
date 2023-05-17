using UnityEngine;

public class SmallCircleEnemyMovementController : MonoBehaviour
{
    [SerializeField] private float rightWall, leftWall, lowerWall;
    [SerializeField] [Range(0, 5)] private float speed;
    [SerializeField] [Range(-1, 1)] private int direction;
    private Transform _transform;
    private Vector3 _tempVector, _firstPosition;

    private void Start()
    {
        _tempVector.z = 0;
        _tempVector.y = -1;
        _tempVector.x = direction;
        _transform = transform;
        _firstPosition = _transform.localPosition;
    }

    private void FixedUpdate()
    {
        if (IsInGameZone())
        {
            _transform.position += _tempVector * speed;
        }
        else
        {
            _transform.localPosition = _firstPosition;
            gameObject.SetActive(false);
        }
    }

    private bool IsInGameZone()
    {
        return (_transform.position.x > leftWall && _transform.position.x < rightWall && _transform
            .position
            .y > lowerWall);
    }

    private void OnTriggerEnter2D(Component other)
    {
        if(!other.gameObject.layer.Equals(6))return;
        ExplosionAnimationSpawner.Instance.SpawnExplosionAnimation(_transform.position);
        _transform.localPosition = _firstPosition;
        gameObject.SetActive(false);
    }
}
