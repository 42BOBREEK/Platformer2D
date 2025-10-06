using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _targets;
    [SerializeField] private int _targetIndex;
    [SerializeField] private float _jumpingForce;
    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;
    private EnemyAnimator _animator;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        _animator = GetComponent<EnemyAnimator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.TryGetComponent<EnemyTarget>(out EnemyTarget target) == true)
        {
            _targetIndex++;

            if(_targetIndex == _targets.Length)
                _targetIndex = 0;
        }
    }

    private void Update()
    {
        if(_groundChecker.IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * _jumpingForce, ForceMode2D.Impulse);

            _animator.SetJumpedTrigger();
        }
    }

    public void ChasePlayer(Transform player)
    {
        Vector2 direction = (player.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(transform.position, player.position, _speed * Time.deltaTime);
    }

    public void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position,  _targets[_targetIndex].position, _speed * Time.deltaTime);
    }
}
