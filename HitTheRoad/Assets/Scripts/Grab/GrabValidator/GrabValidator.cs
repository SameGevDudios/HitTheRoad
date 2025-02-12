using UnityEngine;

public class GrabValidator : IGrabValidator
{
    private IInput _input;
    private bool _grabbed;

    public GrabValidator(IInput input)
    {
        _input = input;
    }
    public void Grabbed()
    {
        _grabbed = true;
    }
    public void Released() 
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
            return hit.collider.CompareTag("Pickup");
        }
        return false;
    }
}
