using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _speed;
    private IInput _input;

    private void Update()
    {
        Move();
    }
    public void Constructor(IInput input, float speed)
    {
        _input = input;
        _speed = speed;
    }
    private void Move()
    {
        transform.Translate(_input.Movement() * _speed * Time.deltaTime);
    }
}
