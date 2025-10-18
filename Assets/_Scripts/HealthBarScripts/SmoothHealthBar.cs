using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private float _maximumChangeValue;
    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private int _heightToAdd;

    private Slider _slider;
    private float _valueChangeTo;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        ChangeBarValue(_health.CurrentHealth);

        if(_target == null)
        {
            gameObject.SetActive(false);

            return;
        }

        Vector2 targetPos = _camera.WorldToScreenPoint(_target.position);
        _rectTransform.position = new Vector2(targetPos.x, targetPos.y + _heightToAdd);
    }

    private void ChangeBarValue(float value)
    {
        _slider.value = Mathf.MoveTowards(_slider.value, value, _maximumChangeValue);
    }
}
