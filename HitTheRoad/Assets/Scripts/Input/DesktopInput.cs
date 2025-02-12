using UnityEngine;

public class DesktopInput : IInput
{
    public Vector3 Movement() =>
        new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    public Vector2 Look() =>
        new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    public bool Jump() =>
        Input.GetButtonDown("Jump");
    public bool Grab() =>
        Input.GetMouseButtonDown(0);
}
