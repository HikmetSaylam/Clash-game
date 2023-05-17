using System.Collections;
using UnityEngine;

public class CircleEnemiesManager : MonoBehaviour
{
    [SerializeField] private float spawningInterval;
    [SerializeField] private float minSpawnPosX, maxSpawnPosX;
    [SerializeField] private float minSpeed, maxSpeed;
    private Vector3 _tempPos;

    private void Start()
    {
        _tempPos.y = 6;
        _tempPos.z = 1;
        StartCoroutine(SpawnCircleEnemy());
    }
    
    private IEnumerator SpawnCircleEnemy()
    {
        var waiter = new WaitForSeconds(spawningInterval);
        while (true)
        {
            _tempPos.x = Random.Range(minSpawnPosX, maxSpawnPosX);
            var circle = ObjectPool.Instance.GetGameObject(ObjectPool.ObjectType.CircleEnemy, _tempPos);
            circle.GetComponent<CircleEnemyMovementController>().SetCircleStats(
                Random.Range(minSpeed, maxSpeed),
                Mathf.RoundToInt(Random.Range(-10, 10)) >= 0 ? -1 : 1);
            yield return waiter;
        }
    }
}
