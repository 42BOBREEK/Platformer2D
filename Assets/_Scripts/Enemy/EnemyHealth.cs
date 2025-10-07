using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _minimumHealth;

    public int Health => _health;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <=_minimumHealth)
        {
            Destroy(gameObject);
        }
    }

}
