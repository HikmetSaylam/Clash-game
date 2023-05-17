using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimator : MonoBehaviour
{
    [SerializeField] private Transform[] circles;
    [SerializeField] [Range(0, 12)] private float animationSpeed;
    [SerializeField] private float colorReductionAmount;
    private List<SpriteRenderer> _spriteRenderers;
    private float _currentColorAValue;
    private Color _tempColor, _firstColor;
    private List<Vector3> _firstPositions;

    private void Awake()
    {
        _spriteRenderers = new List<SpriteRenderer>();
        _firstPositions = new List<Vector3>();
        foreach (var circle in circles)
        {
            _firstPositions.Add(circle.localPosition);
            _spriteRenderers.Add(circle.GetComponent<SpriteRenderer>());
        }
        _firstColor = _spriteRenderers[0].color;
        _currentColorAValue = _firstColor.a;
    }

    public void ApplyExplosion()
    {
        ResetCircles();
        StartCoroutine(ApplyExplosionAnimation());
    }

    private IEnumerator ApplyExplosionAnimation()
    {
        while (_currentColorAValue>=0)
        {
            for (var i = 0; i < circles.Length; i++)
            {
                circles[i].position += (circles[i].rotation * Vector2.right * animationSpeed * Time.deltaTime);
                _tempColor =  _spriteRenderers[i].color;
                _tempColor.a -= colorReductionAmount;
                _spriteRenderers[i].color = _tempColor;
            }
            _currentColorAValue -= colorReductionAmount;
            yield return null;
        }
        _currentColorAValue = _firstColor.a;
    }

    private void ResetCircles()
    {
        for (var i = 0; i < circles.Length; i++)
        {
            circles[i].localPosition = _firstPositions[i];
            _spriteRenderers[i].color = _firstColor;
        }
    }
}
