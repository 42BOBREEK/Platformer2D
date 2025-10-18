using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _minimumHealth;
    [SerializeField] private int _maximumHealth;

    private ItemsCollector _collector;

    public int CurrentHealth { get; private set; }
    public int MaximumHealth => _maximumHealth;

    private void Awake()
    {
        _collector = GetComponent<ItemsCollector>();
        CurrentHealth = _maximumHealth;
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
        CurrentHealth += kit.HealthToHeal;
        if(CurrentHealth > _maximumHealth)
            CurrentHealth = _maximumHealth;
    }

    public void Heal(int health)
    {
        CurrentHealth += health;
        if(CurrentHealth > _maximumHealth)
            CurrentHealth = _maximumHealth;
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;

        if(CurrentHealth <=_minimumHealth)
        {
            Destroy(gameObject);
        }
    }
}
