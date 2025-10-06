using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _dealingDamage;

    public int DealingDamage => _dealingDamage;
}
