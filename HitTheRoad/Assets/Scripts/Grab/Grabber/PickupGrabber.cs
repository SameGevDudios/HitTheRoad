using UnityEngine;

public class PickupGrabber : IGrabber
{
    private SpringJoint _joint;
    public void Grab(GameObject pickup)
    {
        // Add and setup spring joint
    }
    public void Release()
    {
        Object.Destroy(_joint);
    }
}
