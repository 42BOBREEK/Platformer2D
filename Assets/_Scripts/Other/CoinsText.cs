using UnityEngine;
using TMPro;

public class CoinsText : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ItemsCollector _collector;
    [SerializeField] private string _coinsText;

    private void Update()
    {
        _text.text = _coinsText + _collector.CoinsCollected.ToString();
    }
}
