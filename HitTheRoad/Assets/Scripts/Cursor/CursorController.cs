using UnityEngine;

public class CursorController : MonoBehaviour
{
    private void Start()
    {
        LockCursor();
    }
    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
