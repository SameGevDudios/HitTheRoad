using UnityEngine;

public class SafeZone : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameObject pickup = collision.gameObject;
        Rigidbody rigidbody = pickup.GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        pickup.transform.position = new Vector3(
            pickup.transform.position.x,
            2,
            pickup.transform.position.z);
    }
}
