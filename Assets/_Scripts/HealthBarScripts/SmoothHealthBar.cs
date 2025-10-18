using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private float _maximumChangeValue;

    private Slider _slider;
    private float _valueChangeTo;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        ChangeBarValue(_player.Health);
    }

    private void ChangeBarValue(float value)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, value, _maximumChangeValue);
    }
}
