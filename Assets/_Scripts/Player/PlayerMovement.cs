using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private InputReader _input;

    private PlayerAnimator _animator;
    private Rotater _rotater;

    private void Awake()
    {
        _animator = GetComponent<PlayerAnimator>();
        _rotater = GetComponent<Rotater>();
    }

    private void OnEnable()
    {
        _input.JumpClicked += Jump;
    }

    private void OnDisable()
    {
        _input.JumpClicked -= Jump;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_input.HorizontalInput * _speed, _rigidbody.velocity.y);

        _rotater.FlipSprite(_input.HorizontalInput);

        _animator.SetRunningBool(_input.HorizontalInput != 0f && _groundChecker.IsGrounded());
        _animator.SetFallingBool(!_groundChecker.IsGrounded());
    }

    private void Jump()
    {
        if(_groundChecker.IsGrounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpingForce);

            _animator.SetJumpedTrigger();
        }
    }

}
