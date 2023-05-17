using UnityEngine;

public class ExplosionAnimationSpawner : MonoSingleton<ExplosionAnimationSpawner>
{
    public void SpawnExplosionAnimation(Vector3 pos)
    {
        var animation = ObjectPool.Instance.GetGameObject(
            ObjectPool.ObjectType.ExplosionAnimation, pos);
        animation.GetComponent<ExplosionAnimator>().ApplyExplosion();
    }
}