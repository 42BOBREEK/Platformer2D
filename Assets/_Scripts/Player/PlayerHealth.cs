using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _minimumHealth;
    [SerializeField] private int _maximumHealth;

    private ItemsCollector _collector;

    public int Health { get; private set; }
    public int MaximumHealth => _maximumHealth;

    private void Awake()
    {
        _collector = GetComponent<ItemsCollector>();
        Health = _maximumHealth;
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
        Health += kit.HealthToHeal;
        if(Health > _maximumHealth)
            Health = _maximumHealth;
    }

    public void Heal(int health)
    {
        Health += health;
        if(Health > _maximumHealth)
            Health = _maximumHealth;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        if(Health <=_minimumHealth)
        {
            Destroy(gameObject);
        }
    }
}
