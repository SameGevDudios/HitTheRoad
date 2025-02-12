using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform _cameraTransform;
    private float _sensitivity, _verticalLookRotation;
    private IInput _input;
    public void Constructor(Transform cameraTransform, float sensitivity, IInput input)
    {
        _cameraTransform = cameraTransform;
        _sensitivity = sensitivity;
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
