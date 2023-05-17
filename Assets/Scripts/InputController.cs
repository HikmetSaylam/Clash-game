using UnityEngine;

public class InputController : MonoSingleton<InputController>
{
    private bool _isFiring;
    public float GetHorizontal()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool IsFiring()
    {
        if (!_isFiring) return false;
        _isFiring = false;
        return true;
    }

    public void FireOnClicked()
    {
        _isFiring = true;
    }
    
    
}
