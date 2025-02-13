using UnityEngine;

public class GrabController : MonoBehaviour
{
    private GameObject _releaseButton;
    private IInput _input;
    private IGrabValidator _grabValidator;
    private IHighlightController _highlightController;
    private IGrabber _grabber;

    public void Constructor(GameObject releaseButton,
        IInput input, IGrabValidator grabValidator, IHighlightController highlightController, IGrabber grabber)
    {
        _releaseButton = releaseButton;
        _input = input;
        _grabValidator = grabValidator;
        _highlightController = highlightController;
        _grabber = grabber;
    }

    private void Update()
    {
        _highlightController.SearchForPickups();
        if(_input.Grab() && !_grabValidator.Grabbed())
        {
            if (_grabValidator.CanGrab(out GameObject pickup) &&
                _highlightController.PickupInRange())
            {
                StartGrab(pickup);
            }
        }
    }
    private void StartGrab(GameObject pickup)
    {
        _grabber.Grab(pickup);
        _grabValidator.Grab();
        _releaseButton.SetActive(true);
    }
    public void StopGrab()
    {
        _grabber.Release();
        _grabValidator.Release();
        _releaseButton.SetActive(false);
    }
}
