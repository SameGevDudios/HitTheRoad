using UnityEngine;

public class MobileInput : IInput
{
    private UIVirtualJoystick _joystick;
    private Vector2 _previousTouchPosition;

    public MobileInput(UIVirtualJoystick joystick)
    {
        _joystick = joystick;
    }
    public Vector3 Movement()
    {
        Vector3 movement = new Vector3(_joystick.CurrentInput.x,
            0,
            _joystick.CurrentInput.y);
        if(movement.magnitude > 0)
            movement.Normalize();
        return movement;
    }

    public Vector2 Look()
    {
        if (Input.touchCount < 1)
            return Vector2.zero;
        Vector2 delta = Input.GetTouch(0).position - _previousTouchPosition;
        _previousTouchPosition = Input.GetTouch(0).position;
        return delta;
    }
    public Vector3 GrabPoint()
    {
        if (Input.touchCount > 0)
        {
            return Input.GetTouch(0).position;
        }
        return Vector3.zero;
    }
    public bool Grab() =>
        Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
}
