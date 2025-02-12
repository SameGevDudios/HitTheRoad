using UnityEngine;

public class DesktopInput : IInput
{
    public Vector2 Movement() =>
        new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    public Vector2 Look() =>
        new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    public bool Jump() =>
        Input.GetButtonDown("Jump");
    public bool Grab() =>
        Input.GetMouseButtonDown(0);
}
