using UnityEngine;

public interface IInput 
{ 
    Vector2 Movement();
    Vector2 Look();
    bool Jump();
    bool Grab();
}
