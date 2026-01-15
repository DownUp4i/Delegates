using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private Transform _currencyParent;

    [SerializeField] private CurrencyView _coinPrefab;
    [SerializeField] private CurrencyView _diamonPrefab;
    [SerializeField] private CurrencyView _energyPrefab;

    private CurrencyView _coin;
    private CurrencyView _diamond;
    private CurrencyView _energy;

    private Wallet _wallet;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;

        _wallet.ValueChanged += UpdateUICoin;

        _coin = Instantiate(_coinPrefab, _currencyParent);
        _diamond = Instantiate(_diamonPrefab, _currencyParent);
        _energy = Instantiate(_energyPrefab, _currencyParent);

        _coin.UpdateValue(wallet.GetValueBy(CoinType.Coin));
        _diamond.UpdateValue(wallet.GetValueBy(CoinType.Diamond));
        _energy.UpdateValue(wallet.GetValueBy(CoinType.Energy));

    }

    private void UpdateUICoin(CoinType type, int value)
    {
        if (type == CoinType.Coin)
            _coin.UpdateValue(value);

        if (type == CoinType.Diamond)
            _diamond.UpdateValue(value);

        if (type == CoinType.Energy)
            _energy.UpdateValue(value);
    }

    private void OnDestroy()
    {
        _wallet.ValueChanged -= UpdateUICoin;
    }
}

