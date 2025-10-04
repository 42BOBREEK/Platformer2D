using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _targetA;
    [SerializeField] private Transform _targetB;
    [SerializeField] private float _jumpCooldown;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private bool _isJumping;
    [SerializeField] private Transform _groundChecker;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody;
    private bool _isGoingToA;

    public event Action Jumped;
    public bool IsFalling => !IsGrounded();

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.GetComponent<EnemyTarget>() != null)
        {
            _isGoingToA = !_isGoingToA;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundChecker.position, 0.2f, _groundLayer);
    }

    private void Update()
    {
        GoToTarget();

        if(IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * _jumpingForce, ForceMode2D.Impulse);
            Jumped?.Invoke();
        }
    }

    private void GoToTarget()
    {
        float horizontalSpeed = _isGoingToA ? _speed : -_speed;
        _rigidbody.velocity = new Vector2(horizontalSpeed, _rigidbody.velocity.y);
    }
}
