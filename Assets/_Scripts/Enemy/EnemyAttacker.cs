using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            int damageToDeal = GetComponent<EnemyHealth>().DealingDamage;

            GetComponent<PlayerHealth>().TakeDamage(damageToDeal);
        }
    }
}
