using UnityEngine;

public class PlayerMovementController : MonoSingleton<PlayerMovementController>
{
    [SerializeField] [Range(0, 2)] private float speed; 
    private Transform _transform;
    private Vector3 _tempPos;

    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        _tempPos = _transform.position;
        _tempPos.x += (InputController.Instance.GetHorizontal() * speed);
        _tempPos.x = Mathf.Clamp(_tempPos.x, -8.5f, 7.25f);
        _transform.position = _tempPos;
    }

    private void OnTriggerEnter2D(Component other)
    {
        if(!other.gameObject.layer.Equals(3))return;
        ExplosionAnimationSpawner.Instance.SpawnExplosionAnimation(_transform.position);
    }
}
