using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField] private int _healthToHeal;

    public int HealthToHeal => _healthToHeal;
}
