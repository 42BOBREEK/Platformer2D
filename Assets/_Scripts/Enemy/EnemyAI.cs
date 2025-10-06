using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private int _maximumDistance;
    [SerializeField] private EnemyMovement _enemyMovement;

    private Transform _player;
    private float _distance;

    private void Update()
    {   
        Collider2D hit = Physics2D.OverlapCircle(transform.position, _maximumDistance, _playerLayer);

        if(hit != null)
        {
            _player = hit.transform;
            _distance = Vector2.Distance(transform.position, _player.position);

            if(_distance < _maximumDistance)
            {
                _enemyMovement.ChasePlayer(_player);
            }
            else 
            {
                _enemyMovement.Patrol();
            }
        }
        else 
        {
            _enemyMovement.Patrol();
        }
    }
}
