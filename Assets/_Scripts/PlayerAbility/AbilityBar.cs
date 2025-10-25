using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour
{
    [SerializeField] private Caster _caster;
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
        ChangeBarValue();

        if(_target == null)
        {
            gameObject.SetActive(false);

            return;
        }

        Vector2 targetPos = _camera.WorldToScreenPoint(_target.position);
        _rectTransform.position = new Vector2(targetPos.x, targetPos.y + _heightToAdd);
    }

    private void ChangeBarValue()
    {
        if(_caster.IsActive == true)
        {
            _slider.maxValue = _caster.ActiveSeconds;
            _slider.value = Mathf.MoveTowards(_slider.value, _caster.ActiveTimeLeft, _maximumChangeValue);
        }
        else 
        {
            _slider.maxValue = _caster.CooldownSeconds;
            _slider.value = Mathf.MoveTowards(_slider.value, _caster.CooldownTimePassed, _maximumChangeValue);
        }
    }
}
