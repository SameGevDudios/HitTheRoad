using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    private IInput _input;

    private void Start()
    {
        // Temporary call point
        Constructor(new DesktopInput());
    }
    private void Update()
    {
        Move();
    }
    public void Constructor(IInput input)
    {
        _input = input;
    }
    private void Move()
    {
        transform.Translate(_input.Movement() * _speed * Time.deltaTime);
    }
}
