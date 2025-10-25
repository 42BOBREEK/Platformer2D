using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _minimum;
    [SerializeField] private int _maximum;

    private ItemsCollector _collector;

    public float Current ;

    public int Maximum => _maximum;
    public float Minimum => _minimum;

    public event Action GotBelowMinimum;

    private void Awake()
    {
        _collector = GetComponent<ItemsCollector>();
        Current = _maximum;
    }

    public void Heal(float healthToAdd)
    {
        Current += healthToAdd;

        if(Current > _maximum)
            Current = _maximum;
    }

    public void TakeDamage(float damage)
    {
        Current -= damage;

        if(Current <=_minimum)
        {
            GotBelowMinimum?.Invoke();
        }
    }
}
