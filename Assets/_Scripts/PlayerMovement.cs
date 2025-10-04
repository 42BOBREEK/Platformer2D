using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private InputReader _input;
    [SerializeField] private bool _isFacingRight = true;

    public bool IsRunning { get; private set; }
    public bool IsFalling { get; private set; }

    public event Action Jumped;

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_input.HorizontalInput * _speed, _rigidbody.velocity.y);

        FlipSprite();

        IsRunning = (_input.HorizontalInput != 0f);

        IsFalling = !IsGrounded();
    }

    private void Jump()
    {
        if(IsGrounded() == true)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpingForce);
            Jumped?.Invoke();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundChecker.position, 0.2f, _groundLayer);
    }

    private void FlipSprite()
    {
        if(_isFacingRight == true && _input.HorizontalInput < 0f 
                || _isFacingRight == false && _input.HorizontalInput > 0f)
        {
            _isFacingRight = !_isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnEnable()
    {
        _input.JumpClicked += Jump;
    }

    private void OnDisable()
    {
        _input.JumpClicked -= Jump;
    }
}
