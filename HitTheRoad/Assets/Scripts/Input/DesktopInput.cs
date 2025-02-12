using UnityEngine;

public class DesktopInput : IInput
{
    public Vector3 Movement() =>
        new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    public Vector2 Look() =>
        new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    public Vector3 GrabPoint() =>
        new Vector3(Screen.width / 2, Screen.height / 2, 0);
    public bool Jump() =>
        Input.GetButtonDown("Jump");
    public bool Grab() =>
        Input.GetMouseButtonDown(0);
}
