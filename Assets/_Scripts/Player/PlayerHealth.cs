using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _minimumHealth;
    
    private ItemsCollector _collector;

    private void Awake()
    {
        _collector = GetComponent<ItemsCollector>();
    }

    private void OnEnable()
    {
        _collector.FoundKit += HealByKit;
    }

    private void OnDisable()
    {
        _collector.FoundKit -= HealByKit;
    }

    public void HealByKit(Medkit kit)
    {
        _health += kit.HealthToHeal;
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
