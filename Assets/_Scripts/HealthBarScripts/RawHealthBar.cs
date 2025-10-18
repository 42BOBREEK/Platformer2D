using UnityEngine;
using UnityEngine.UI;

public class RawHealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;

    private Slider _slider;

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
        _slider.value = value;
    }
}
