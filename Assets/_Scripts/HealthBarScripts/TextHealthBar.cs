using UnityEngine;
using TMPro;

public class TextHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private PlayerHealth _player;

    private void Update()
    {
        _text.text = _player.Health.ToString() + '/' + _player.MaximumHealth.ToString();
    }
}
