using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currency;

    public void UpdateValue(int value) => _currency.text = value.ToString();
}
