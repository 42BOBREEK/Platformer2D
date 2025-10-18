using UnityEngine;
using UnityEngine.UI;

public class RawHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        ChangeBarValue(_health.CurrentHealth);
    }

    private void ChangeBarValue(float value)
    {
        _slider.value = value;
    }
}
