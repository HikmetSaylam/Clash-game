using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadAnimator : MonoBehaviour
{
    [SerializeField] private Transform rightWeapon, leftWeapon, upperPlatform, lowerPlatform;
    [SerializeField] [Range(0, 12)] private float animationSpeed;
    [SerializeField] private float colorReductionAmount;
    private Vector3 _rightWeaponAxis, _leftWeaponAxis, _upperWeaponPlatform, _lowerWeaponPlatform;
    private List<SpriteRenderer> _spriteRenderers;
    private Color _tempColor;

    private void Start()
    {
        _spriteRenderers = new List<SpriteRenderer>();
        _rightWeaponAxis = new Vector3(1, -1, 0);
        _leftWeaponAxis = new Vector3(-1, -1, 0);
        _upperWeaponPlatform = new Vector3(0, 1, 0);
        _lowerWeaponPlatform = new Vector3(0, -1, 0);
        _spriteRenderers.Add(rightWeapon.GetComponent<SpriteRenderer>());
        _spriteRenderers.Add(leftWeapon.GetComponent<SpriteRenderer>());
        _spriteRenderers.Add(upperPlatform.GetComponent<SpriteRenderer>());
        _spriteRenderers.Add(lowerPlatform.GetComponent<SpriteRenderer>());
    }

    private void FixedUpdate()
    {
        if(GameManager.Instance.IsEnemyDead)
            ApplyAnimation();
    }

    private void ApplyAnimation()
    {
        foreach (var item in _spriteRenderers)
        {
            _tempColor = item.color;
            _tempColor.a -= colorReductionAmount;
            item.color = _tempColor;
        }

        rightWeapon.position += _rightWeaponAxis * animationSpeed;
        leftWeapon.position += _leftWeaponAxis * animationSpeed;
        upperPlatform.position += _upperWeaponPlatform * animationSpeed;
        lowerPlatform.position += _lowerWeaponPlatform * animationSpeed;
        rightWeapon.Rotate(0,0,5);
        leftWeapon.Rotate(0,0,5);
        upperPlatform.Rotate(0,0,5);
        lowerPlatform.Rotate(0, 0, 5);

    }

}
