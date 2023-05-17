using UnityEngine;

public class DoubleFireApplier : MonoBehaviour
{
    [SerializeField] private int animationSpeed;
    [SerializeField] private float colorReductionAmount;
    [SerializeField] private float rightWall, leftWall, upperWall, lowerWall;
    private Transform _transform;
    private SpriteRenderer _spriteRenderer;
    private Color _color;
    private Vector3 _rotationVector;

    private void Start()
    {
        _transform = transform;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;
        _rotationVector = Vector3.zero;
        _rotationVector.z = animationSpeed;
        SetPosition();
    }

    private void FixedUpdate()
    {
        ApplyAnimation();
    }
    
    private void ApplyAnimation()
    {
        _transform.Rotate(_rotationVector);
        _color.a -= colorReductionAmount;
        _spriteRenderer.color = _color;
        if(_color.a<=0)
            Destroy(gameObject);
    }

    private void SetPosition()
    {
        var posXAxis = Random.Range(leftWall, rightWall);
        var posYAxis = Random.Range(lowerWall, upperWall);
        _transform.position = new Vector3(posXAxis, posYAxis, 0);
    }

    private void OnTriggerEnter2D(Component other)
    {
        if(!other.tag.Equals("PlayerBullet"))return;
        PlayerFireController.Instance.IsDoubleFiring = true;
        Destroy(gameObject);
    }
}
