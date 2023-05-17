using UnityEngine;

public class PlayerFireController : MonoSingleton<PlayerFireController>
{
    public bool IsDoubleFiring { get; set; }
    private WeaponController _weaponController;
    private int counter;

    private void Start()
    {
        _weaponController = GetComponent<WeaponController>();
    }

    private void FixedUpdate()
    {
        if (!InputController.Instance.IsFiring()) return;
        if (IsDoubleFiring)
        {
            _weaponController.Fire(1);
            _weaponController.Fire(2);
            return;
        }
        _weaponController.Fire(0);
        
    }
}