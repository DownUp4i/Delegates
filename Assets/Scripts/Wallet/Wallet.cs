using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CoinType, int> _wallet;

    public Action<CoinType, int> ValueChanged;

    public Wallet(Dictionary<CoinType, int> wallet)
    {
        _wallet = new Dictionary<CoinType, int>(wallet);
    }

    public void AddValue(CoinType type, int value)
    {
        if (_wallet.ContainsKey(type))
        {
            if (value > 0)
            {
                _wallet[type] += value;
                ValueChanged?.Invoke(type, _wallet[type]);
            }
        }
    }

    public void RemoveValue(CoinType type, int value)
    {
        if (_wallet.ContainsKey(type))
        {
            if (_wallet[type] >= value && value >= 0)
            {
                _wallet[type] -= value;
                ValueChanged?.Invoke(type, _wallet[type]);
            }
        }
    }

    public int GetValueBy(CoinType type) => _wallet[type];
}
