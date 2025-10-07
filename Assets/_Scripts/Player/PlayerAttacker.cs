using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    [SerializeField] private int _dealingDamage;

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        {
            enemy.TakeDamage(_dealingDamage);
        }
    }
}
