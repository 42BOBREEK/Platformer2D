using UnityEngine;

[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private  GroundChecker _groundChecker;

    private PlayerAnimator _animator;
    private PlayerMovement _movement;
    private Rotater _rotater;
    private Health _health;
    private ItemsCollector _collector;

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void Awake()
    {
        _health = GetComponent<Health>();
        _collector = GetComponent<ItemsCollector>();
        _animator = GetComponent<PlayerAnimator>();
        _movement = GetComponent<PlayerMovement>();
        _rotater = GetComponent<Rotater>();
    }

    private void FixedUpdate()
    {
        _movement.Move(_input.HorizontalInput);

        _animator.SetRunningBool(_input.HorizontalInput != 0f && _groundChecker.IsGrounded());

        _animator.SetFallingBool(!_groundChecker.IsGrounded());
 
        _rotater.FlipSprite(_input.HorizontalInput);
    }

    private void OnEnable()
    {
        _input.JumpClicked += Jump;
        _health.GotBelowMinimum += DestroySelf;
        _collector.FoundKit += HealByKit;
    }

    private void OnDisable()
    {
        _input.JumpClicked -= Jump;
        _health.GotBelowMinimum += DestroySelf;
        _collector.FoundKit -= HealByKit;
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    private void HealByKit(Medkit kit)
    {
        _health.Heal(kit.HealthToHeal);
    }

    private void Jump()
    {
        if(_groundChecker.IsGrounded())
        {
            _movement.Jump();
            _animator.SetJumpedTrigger();
        }
    }
}
