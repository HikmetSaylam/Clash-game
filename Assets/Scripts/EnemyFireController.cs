using System.Collections;
using UnityEngine;

public class EnemyFireController : MonoSingleton<EnemyFireController>
{
    [SerializeField] private float firingInterval;
    private WeaponController _weaponController;
    private int _barrelCounter;

    private void Start()
    {
        _weaponController = GetComponent<WeaponController>();
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        var timer = new WaitForSeconds(firingInterval);
        while (true)
        {
            yield return timer;
            _weaponController.Fire(_barrelCounter++%_weaponController.FiringPoints);
        }
    }
}
