using UnityEngine;
using Zenject;

[RequireComponent(typeof(UIVirtualJoystick))]
public class MovementJoystick : MonoBehaviour
{
    [Inject] private IInput _input;
    private MobileInput _mobileInput;
    private UIVirtualJoystick _joystick;

    private void Awake()
    {
        if (_input is MobileInput)
            _mobileInput = (MobileInput)_input;
        else
            gameObject.SetActive(false);

        _joystick = GetComponent<UIVirtualJoystick>();
    }
    private void Update()
    {
        Vector3 movement = new Vector3(
            _joystick.CurrentInput.x,
            0,
            _joystick.CurrentInput.y);
        _mobileInput.SetMovement(movement);
    }
}
