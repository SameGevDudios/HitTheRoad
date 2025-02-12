using UnityEngine;

public class GrabValidator : IGrabValidator
{
    private IInput _input;
    private bool _grabbed;

    public GrabValidator(IInput input)
    {
        _input = input;
    }
    public void Grab()
    {
        _grabbed = true;
    }
    public void Release() 
    {
        _grabbed = false;
    }
    public bool CanGrab(out GameObject pickup)
    {
        pickup = null;
        if (_grabbed)
            return false;
        Ray ray = Camera.main.ScreenPointToRay(_input.GrabPoint());
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            pickup = hit.collider.gameObject;
            return hit.collider.CompareTag("Pickup") && pickup != null;
        }
        return false;
    }
    public bool Grabbed() =>
        _grabbed;
}
