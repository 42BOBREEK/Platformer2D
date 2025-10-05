using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _minimumHealth;
    
    private void Update()
    {
        if(_health <=_minimumHealth)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
    }
}
