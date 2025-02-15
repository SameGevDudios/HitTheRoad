using UnityEngine;
using UnityEngine.UI;
using Zenject;

[RequireComponent(typeof(Button))]
public class GrabButton : MonoBehaviour
{
    [Inject] private IInput _input;
    private MobileInput _mobileInput;
    private Button _button;

    private void Awake()
    {
        if(_input is MobileInput)
            _mobileInput = (MobileInput)_input;
        else
            gameObject.SetActive(false);

        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => _mobileInput.SetGrab(true));
    }
    private void Update()
    {
        _mobileInput.SetGrab(false);
    }
}
