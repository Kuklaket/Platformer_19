using UnityEngine;
using TMPro;

public class CoinsCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private int _coinCount = 0;

    private void Start()
    {
        UpdateText();
    }

    public void AddCoin()
    {
        _coinCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        _text.text = _coinCount.ToString();
    }
}