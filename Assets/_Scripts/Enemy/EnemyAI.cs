using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private int _maximumDistance;
    [SerializeField] private EnemyMovement _enemyMovement;

    private float _distance;

    private void Update()
    {
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
}
