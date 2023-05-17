using System.Collections;
using UnityEngine;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] [Range(0, 1)] private float speed;
    [SerializeField] private float leftWallXAxisValue, rightWallXAxisValue;
    private Transform _transform;
    private Vector3 _currentPos,_nextPos;
    private float _lerpValue;
    private int _positionCounter;

    private void Start()
    {
        _transform = transform;
        SetNextPosition();
        StartCoroutine(MoveEnemy());
    }

    private IEnumerator MoveEnemy()
    {
        while (!GameManager.Instance.IsEnemyDead)
        {
            while (_transform.position!=_nextPos&&!GameManager.Instance.IsEnemyDead)
            {
                _transform.position=Vector3.Lerp(_currentPos,_nextPos,_lerpValue+=(speed*Time.deltaTime));
                yield return null;
            }

            _lerpValue = 0;
            SetNextPosition();
            yield return null;
        }
    }

    private void SetNextPosition()
    {
        _currentPos = _transform.position;
        _nextPos = _transform.position;
        switch (_positionCounter++%4)
        {
            case 0:
                _nextPos.x = rightWallXAxisValue;
                speed /= 5;
                break;
            case 1:
                _nextPos.y = _transform.position.y - 1;
                speed *= 5;
                break;
            case 2:
                _nextPos.x = leftWallXAxisValue;
                speed /= 5;
                break;
            case 3:
                _nextPos.y = _transform.position.y - 1;
                speed *= 5;
                break;
        }
    }

    private void OnTriggerEnter2D(Component other)
    {
        if(!other.gameObject.layer.Equals(6))return;
        GameManager.Instance.IsEnemyDead = true;
        Destroy(gameObject.GetComponent<BoxCollider2D>());
    }
    
}
