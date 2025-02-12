using UnityEngine;

public interface IGrabValidator
{
    void Grab();
    void Release();
    bool CanGrab(out GameObject pickup);
    bool Grabbed();
}
