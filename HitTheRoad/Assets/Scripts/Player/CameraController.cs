using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private float _sensitivity;
    private float _verticalLookRotation;
    private IInput _input;
    private void Start()
    {
        // Temporary call point
        Constructor(new DesktopInput());
    }
    private void Constructor(IInput input)
    {
        _input = input;
    }
    private void Update()
    {
        RotateCamera();
    }
    private void RotateCamera()
    {
        Vector2 mouse = _input.Look();
        float yRotation = mouse.x * _sensitivity;
        transform.Rotate(Vector3.up * yRotation);

        _verticalLookRotation += mouse.y * _sensitivity;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

        _cameraTransform.localEulerAngles = Vector3.left * _verticalLookRotation;
    }
}
