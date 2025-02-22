using UnityEngine;

public class MobileInput : IInput
{
    private Vector3 _movementInput;
    private bool _grabbed;

    public Vector3 Movement()
    {
        if (_movementInput.magnitude > 0)
            _movementInput.Normalize();
        return _movementInput;
    }
    public Vector2 Look() => 
        Input.touchCount > 0 ?
            Input.GetTouch(0).deltaPosition : Vector2.zero;
    public Vector3 GrabPoint() =>
        Input.touchCount > 0 ?
            Input.GetTouch(0).position : Vector2.zero;
    public bool Grab() =>
        _grabbed || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    public void SetGrab(bool grab) =>
        _grabbed = grab;
    public void SetMovement(Vector3 movement) =>
        _movementInput = movement;
}
