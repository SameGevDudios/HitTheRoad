using UnityEngine;

public interface IInput 
{ 
    Vector3 Movement();
    Vector2 Look();
    Vector3 GrabPoint();
    bool Jump();
    bool Grab();
}
