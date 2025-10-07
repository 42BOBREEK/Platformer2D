using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private Rigidbody2D _rigidbody;

    private PlayerAnimator _animator;
    private Rotater _rotater;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _rotater = GetComponent<Rotater>();
    }

    public void Move(float horizontalInput)
    {
        _rigidbody.velocity = new Vector2(horizontalInput * _speed, _rigidbody.velocity.y);
    }

    public void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpingForce);
    }

}
