using UnityEngine;

[RequireComponent(typeof(Health))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private int _maximumDistance;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private int _maxHits;

    private float _distance;
    private Collider2D[] _hits; 
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.GotBelowMinimum += DestroySelf;
    }

    private void OnDisable()
    {
        _health.GotBelowMinimum -= DestroySelf;
    }

    private void Start()
    {
        _hits = new Collider2D[_maxHits];
    }

    private void FixedUpdate()
    {
        int hitsCount = Physics2D.OverlapCircleNonAlloc(transform.position, _maximumDistance, _hits, _playerLayer);

        if (hitsCount > 0)
        {
            _enemyMovement.ChasePlayer(_hits[0].transform);
        }
        else
        {
            _enemyMovement.Patrol();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
