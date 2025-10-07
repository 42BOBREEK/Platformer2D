using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private int _maximumDistance;
    [SerializeField] private EnemyMovement _enemyMovement;
    [SerializeField] private int _maxHits;

    private Transform _player;
    private float _distance;
    private Collider2D[] _hits; 

    private void Start()
    {
        _hits = new Collider2D[_maxHits];
    }

    private void Update()
    {
        int hitsCount = Physics2D.OverlapCircleNonAlloc(transform.position, _maximumDistance, _hits, _playerLayer);

        if (hitsCount > 0)
        {
            _player = _hits[0].transform;
            _enemyMovement.ChasePlayer(_player);
        }
        else
        {
            _enemyMovement.Patrol();
        }
    }

}
