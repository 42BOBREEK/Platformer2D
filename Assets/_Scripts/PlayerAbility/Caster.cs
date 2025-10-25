using UnityEngine;
using System.Collections;

public class Caster : MonoBehaviour
{
    [SerializeField] private InputReader _input;
    [SerializeField] private MagicAbility _ability;
    [SerializeField] private int _activeSeconds;
    [SerializeField] private int _cooldownSeconds;

    private bool _isOnCooldown;
    private bool _isActive;

    private float _cooldownTimeLeft;
    private float _activeTimeLeft;

    public float ActiveTimeLeft => _activeTimeLeft;
    public float ActiveSeconds => _activeSeconds;

    public float CooldownTimePassed => (_cooldownSeconds - _cooldownTimeLeft);
    public float CooldownSeconds => _cooldownSeconds;

    public bool IsOnCooldown => _isOnCooldown;
    public bool IsActive => _isActive;

    private void OnEnable()
    {
        _input.CastClicked += TryToCastAbility;
    }

    private void OnDisable()
    {
        _input.CastClicked -= TryToCastAbility;
    }

    private IEnumerator DisableObject(int secondsToWait)
    {
        _isActive = true;

        _activeTimeLeft = secondsToWait;

        while (_activeTimeLeft > 0f)
        {
            _activeTimeLeft -= Time.deltaTime;

            yield return null;
        }

        _ability.gameObject.SetActive(false);

        _isActive = false;

        StartCoroutine(DisableCooldown(_cooldownSeconds));
    }


    private IEnumerator DisableCooldown(int secondsToWait)
    {
        _isOnCooldown = true;

        _cooldownTimeLeft = secondsToWait;

        while (_cooldownTimeLeft > 0f)
        {
            _cooldownTimeLeft -= Time.deltaTime;

            yield return null;
        }

        _isOnCooldown = false;

        _cooldownTimeLeft = 0f;
    }

    private void TryToCastAbility()
    {
        if(_isOnCooldown == false)
        {
            _ability.gameObject.SetActive(true);

            StartCoroutine(DisableObject(_activeSeconds));
        }
    }
}
