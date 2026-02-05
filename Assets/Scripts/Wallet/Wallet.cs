using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CoinType, IReadOnlyReactiveVariable<int>> _wallet;

    public Wallet(Dictionary<CoinType, IReadOnlyReactiveVariable<int>> wallet)
    {
        _wallet = new Dictionary<CoinType, IReadOnlyReactiveVariable<int>>(wallet);
    }

    public IReadOnlyDictionary<CoinType, IReadOnlyReactiveVariable<int>> WalletBalance => _wallet;

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
