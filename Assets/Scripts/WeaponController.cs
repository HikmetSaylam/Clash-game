using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform[] firingPoints;
    [SerializeField] private ObjectPool.ObjectType bulletType;
    private int _bulletCounter;

    public int FiringPoints => firingPoints.Length;

    public void Fire(int barrel)
    {
        var bullet =
            ObjectPool.Instance.GetGameObject(bulletType,
                firingPoints[barrel].position);
        bullet.GetComponent<BulletMovementController>().Fire();
    }
}