using UnityEngine;

public class GrabController : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _grabRadius;
    [SerializeField] private LayerMask _grabMask;
    private IInput _input;
    private IGrabValidator _grabValidator;
    private IHighlightController _highlightController;
    private IGrabber _grabber;

    private void Start()
    {
        // Temporary call point
        IInput input = new DesktopInput();
        IGrabValidator validator = new GrabValidator(input);
        IHighlightController highlightController = new RangeHighlightController(_playerTransform, _grabRadius, _grabMask);
        IGrabber grabber = new PickupGrabber();
        Constructor(input, validator, highlightController, grabber);
    }
    private void Constructor(IInput input, IGrabValidator grabValidator, IHighlightController highlightController, IGrabber grabber)
    {
        _input = input;
        _grabValidator = grabValidator;
        _highlightController = highlightController;
        _grabber = grabber;
    }
    private void Update()
    {
        _highlightController.SearchForPickups();
        if (_highlightController.PickupInRange())
        {
            if(_input.Grab()) 
            {
                if (_grabValidator.Grabbed())
                {
                    StopGrab();
                }
                else if (_grabValidator.CanGrab(out GameObject pickup))
                {
                    StartGrab(pickup);
                }
            }
        }
    }
    private void StartGrab(GameObject pickup)
    {
        _grabber.Grab(pickup);
        _grabValidator.Grab();
    }
    private void StopGrab()
    {
        _grabber.Release();
        _grabValidator.Release();
    }
}
