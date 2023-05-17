using UnityEngine;

public class CircleEnemyMovementController : MonoBehaviour
{
    [SerializeField] private float rightWall, leftWall, lowerWall;
    private int _direction; 
    private float _speed;
    private Transform _transform;
    private Vector3 _tempVector;

    private void Start()
    {
        _transform = transform;
        _tempVector = Vector3.zero;
    }

    private void FixedUpdate()
    {
        _transform.position += GetNextPositionPoint();
    }

    public void SetCircleStats(float speed, int direction)
    {
        _speed = speed;
        _direction = direction;
    }

    private Vector3 GetNextPositionPoint()
    {
        if (_transform.position.x >= rightWall || _transform.position.x <= leftWall)
            _direction *= -1;
        _tempVector.x = 1 * _direction;
        _tempVector.y = -1;
        if(_transform.position.y<=lowerWall)
            gameObject.SetActive(false);
        return _tempVector*_speed;
    }

    private void OnTriggerEnter2D(Component other)
    {
        if(!other.gameObject.layer.Equals(6))return;
        ObjectPool.Instance.GetGameObject(ObjectPool.ObjectType.RightSmallCircleEnemy, _transform.position);
        ObjectPool.Instance.GetGameObject(ObjectPool.ObjectType.LeftSmallCircleEnemy, _transform.position);
        gameObject.SetActive(false);
    }
}
