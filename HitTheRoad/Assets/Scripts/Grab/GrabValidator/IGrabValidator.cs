using UnityEngine;

public interface IGrabValidator
{
    void Grabbed();
    void Released();
    bool CanGrab(out GameObject pickup);
}
