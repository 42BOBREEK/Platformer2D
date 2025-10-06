using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _minimumHealth;
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.TryGetComponent<Medkit>(out Medkit medkit) == true)
        {
            Heal(medkit.HealthToHeal);
        }
        else if(coll.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth) == true)
        {
            TakeDamage(enemyHealth.DealingDamage);
        }
    }

    private void Update()
    {
        if(_health <=_minimumHealth)
        {
            Destroy(gameObject);
        }
    }

    private void Heal(int healthToHeal)
    {
        _health += healthToHeal;
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
