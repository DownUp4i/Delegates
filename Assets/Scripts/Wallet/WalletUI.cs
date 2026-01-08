using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private WalletHandler _walletHandler;

    [SerializeField] private TextMeshProUGUI _coinValue;
    [SerializeField] private TextMeshProUGUI _diamondValue;
    [SerializeField] private TextMeshProUGUI _EnergyValue;

    private void Awake()
    {
        _walletHandler.OnAddValue += UpdateUICoin;
        _walletHandler.OnRemoveValue += UpdateUICoin;
    }

    private void UpdateUICoin(WalletType type, int value)
    {
        foreach (WalletItem item in _walletHandler.GetWalletItems())
        {
            if(item.WalletType == WalletType.Coin)
                _coinValue.text = item.Value.ToString();

            if (item.WalletType == WalletType.Diamond)
                _diamondValue.text = item.Value.ToString();

            if (item.WalletType == WalletType.Energy)
                _EnergyValue.text = item.Value.ToString();
        }
    }

    private void OnDestroy()
    {
        _walletHandler.OnAddValue -= UpdateUICoin;
        _walletHandler.OnRemoveValue -= UpdateUICoin;
    }
}

