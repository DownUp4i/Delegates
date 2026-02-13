using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CoinType, ReactiveVariable<int>> _wallet;

    public Wallet(Dictionary<CoinType, int> wallet)
    {
        _wallet = new Dictionary<CoinType, ReactiveVariable<int>>();

        foreach (var currencyTypeAndValue in wallet)
            _wallet[currencyTypeAndValue.Key] = new ReactiveVariable<int>(currencyTypeAndValue.Value);
    }

    public IEnumerable<CoinType> AvailableCurrencies => _wallet.Keys;
    public IReadOnlyDictionary<CoinType, ReactiveVariable<int>> Balance => _wallet;

    public bool TryGetValue(CoinType coinType, out IReadOnlyReactiveVariable<int> value)
    {
        value = null;
        bool found = _wallet.TryGetValue(coinType, out ReactiveVariable<int> sourceValue);

        if (found) 
            value = sourceValue;

        return found;
    }

    public void AddValue(CoinType type, int value)
    {
        if (_wallet.ContainsKey(type))
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _wallet[type].Value += value;
        }
    }

    public bool RemoveValue(CoinType type, int value)
    {
        if (_wallet.ContainsKey(type))
        {
            if (_wallet[type].Value >= value && value >= 0)
            {
                _wallet[type].Value -= value;
                return true;
            }
        }
        return false;
    }

    public int GetValueBy(CoinType type)
    {
        if (_wallet.ContainsKey(type))
            return _wallet[type].Value;

        throw new InvalidOperationException(nameof(type));
    }
}
