using UnityEngine;

public class PickupGrabber : IGrabber
{
    private Transform _armTransform, _cameraTransform;
    private GameObject _pickup;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private float _throwForce;

    public PickupGrabber(Transform armTransform, Transform cameraTransform, float throwForce)
    {
        _armTransform = armTransform;
        _cameraTransform = cameraTransform;
        _throwForce = throwForce;
    }
    public void Grab(GameObject pickup)
    {
        _pickup = pickup;
        GetComponents();
        ActivatePhysics(false);
        BindToArm();
    }
    public void Release()
    {
        ActivatePhysics(true);
        UnbindFromArm();
        Throw();
    }
    private void GetComponents()
    {
        _rigidbody = _pickup.GetComponent<Rigidbody>();
        _collider = _pickup.GetComponent<Collider>();
    }
    private void BindToArm()
    {
        _pickup.transform.position = _armTransform.position;
        _pickup.transform.SetParent(_cameraTransform);
    }
    private void UnbindFromArm()
    {
        _pickup.transform.SetParent(null);
    }
    private void ActivatePhysics(bool activate)
    {
        _rigidbody.isKinematic = !activate;
        _collider.enabled = activate;
    }
    public void Throw()
    {
        _rigidbody.AddForce(_cameraTransform.forward * _throwForce);
    }
}
