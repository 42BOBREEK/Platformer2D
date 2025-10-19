using UnityEngine;
using TMPro;

public class CoinsText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ItemsCollector _collector;
    [SerializeField] private string _coinsText;

    private void Start()
    {
        ChangeText();
    }

    private void OnEnable()
    {
        _collector.FoundCoin += ChangeText;
    }

    private void OnDisable()
    {
        _collector.FoundCoin += ChangeText;
    }

    private void ChangeText()
    {
        _text.text = _coinsText + _collector.CoinsCollected.ToString();
    }
}
