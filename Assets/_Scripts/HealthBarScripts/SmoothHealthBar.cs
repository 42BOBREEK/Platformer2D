using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _maximumChangeValue;

    private Slider _slider;
    private float _valueChangeTo;

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
        _slider.value = Mathf.MoveTowards(_slider.value, value, _maximumChangeValue);
    }
}
