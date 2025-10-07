using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _minimumHealth;
    
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth) == true)
        {
            TakeDamage(enemyHealth.DealingDamage);
        }
    }

    public void Heal(int healthToHeal)
    {
        _health += healthToHeal;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <=_minimumHealth)
        {
            Destroy(gameObject);
        }
    }
}
