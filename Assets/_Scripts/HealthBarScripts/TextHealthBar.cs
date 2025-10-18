using UnityEngine;
using TMPro;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Health _health;

    private void Update()
    {
        _text.text = _health.CurrentHealth.ToString() + '/' + _health.MaximumHealth.ToString();
    }
}
