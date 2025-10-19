using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _minimum;
    [SerializeField] private int _maximum;

    private ItemsCollector _collector;

    public int Current { get; private set; }
    public int Maximum => _maximum;

    public event Action GotBelowMinimum;

    private void Awake()
    {
        _collector = GetComponent<ItemsCollector>();
        Current = _maximum;
    }

    public void Heal(int healthToAdd)
    {
        Current += healthToAdd;

        if(Current > _maximum)
            Current = _maximum;
    }

    public void TakeDamage(int damage)
    {
        Current -= damage;

        if(Current <=_minimum)
        {
            GotBelowMinimum?.Invoke();
        }
    }
}
