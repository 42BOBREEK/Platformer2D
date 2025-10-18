using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HealthButtons : MonoBehaviour
{
    [SerializeField] private PlayerHealth _player;
    [SerializeField] private bool _isHealing;
    [SerializeField] private int _healthToHeal;
    [SerializeField] private int _damageToTake;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(DamageOrHeal);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(DamageOrHeal);
    }

    private void DamageOrHeal()
    {
        if(_player == null)
            return;

        if(_isHealing == true)
            _player.Heal(_healthToHeal);
        else 
            _player.TakeDamage(_damageToTake);
    }
}
