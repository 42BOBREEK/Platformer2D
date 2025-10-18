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

    private void Start()
    {
        _health = GetComponent<Health>();
        _hits = new Collider2D[_maxHits];
    }

    private void Update()
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

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
