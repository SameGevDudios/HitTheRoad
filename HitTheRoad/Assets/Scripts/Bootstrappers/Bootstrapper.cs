using UnityEngine;
using Zenject;

public class Bootstrapper : MonoBehaviour
{
    [Inject] IInput _input;

    [Header("Grab Controller")]
    [SerializeField] private GrabController _grabController;
    [SerializeField] private GameObject _releaseButton;
    [SerializeField] private Transform _playerTransform, _armTransform, _cameraTransform;
    [SerializeField] private float _grabRadius, _throwForce;
    [SerializeField] private LayerMask _grabMask;

    [Header("Player Movement")]
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private float _speed;

    [Header("Camera Controller")]
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private float _sensitivity;

    private void Awake()
    {
        IGrabValidator validator = new GrabValidator(_input);
        IHighlightController highlightController = new RangeHighlightController(_playerTransform, _grabRadius, _grabMask);
        IGrabber grabber = new PickupGrabber(_armTransform, _cameraTransform, _throwForce);
        
        _grabController.Constructor(_releaseButton,
        _input, validator, highlightController, grabber);

        _playerMovement.Constructor(_input, _speed);

        _cameraController.Constructor(_cameraTransform, _sensitivity, _input);
    }
}
