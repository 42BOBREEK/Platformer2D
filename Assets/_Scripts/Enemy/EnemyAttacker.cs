using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    [SerializeField] private int _attackDamage;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            player.TakeDamage(_attackDamage);
        }
    }
}
