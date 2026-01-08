using System;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Wallet
{
    private WalletStorage _storage;

    public Wallet ()
    {
        _storage = new WalletStorage();
    }

    public void InitStorage() => _storage.Init();

    public void OnAddValue(WalletType type, int value)
    {
        foreach(WalletItem item in _storage.WalletItems)
        {
            if(item.WalletType == type)
            {
                item.AddValue(value);
                item.GetInfo();
            }
        }
    }

    public void OnRemoveValue(WalletType type, int value)
    {
        foreach (WalletItem item in _storage.WalletItems)
        {
            if (item.WalletType == type)
            {
                item.RemoveValue(value);
                item.GetInfo();
            }
        }
    }

    public List<WalletItem> GetWalletItems() => _storage.WalletItems;
}
