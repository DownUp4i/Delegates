using TMPro;
using UnityEngine;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currency;
    private IReadOnlyReactiveVariable<int> _reactiveVariable;

    public void Initialize(IReadOnlyReactiveVariable<int> reactiveVariable)
    {
        _reactiveVariable = reactiveVariable;

        _reactiveVariable.Changed += UpdateValue;
    }

    private void OnDestroy()
    {
        _reactiveVariable.Changed -= UpdateValue;
    }

    public void UpdateValue(int value) => _currency.text = value.ToString();
}
