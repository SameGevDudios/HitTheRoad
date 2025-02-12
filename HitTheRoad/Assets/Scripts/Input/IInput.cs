using UnityEngine;

public interface IInput 
{ 
    Vector3 Movement();
    Vector2 Look();
    bool Jump();
    bool Grab();
}
