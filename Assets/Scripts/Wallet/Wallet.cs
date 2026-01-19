using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CoinType, ReactiveVariable<int>> _wallet;

    public Wallet(Dictionary<CoinType, ReactiveVariable<int>> wallet)
    {
        _wallet = new Dictionary<CoinType, ReactiveVariable<int>>(wallet);
    }

    public IReadOnlyDictionary<CoinType, ReactiveVariable<int>> WalletBalance => _wallet;

    public void AddValue(CoinType type, int value)
    {
        if (_wallet.ContainsKey(type))
        {
            if (value > 0)
                _wallet[type].Value += value;
            Debug.Log(_wallet[type].Value);
        }

    }

    public void RemoveValue(CoinType type, int value)
    {
        if (_wallet.ContainsKey(type))
        {
            if (_wallet[type].Value >= value && value >= 0)
                _wallet[type].Value -= value;
        }
    }

    public int GetValueBy(CoinType type) => _wallet[type].Value;
}
