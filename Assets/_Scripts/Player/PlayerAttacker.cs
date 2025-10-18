using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private int _dealingDamage;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.TryGetComponent<EnemyAI>(out EnemyAI enemy))
        {
            enemy.TakeDamage(_dealingDamage);
        }
    }
}
