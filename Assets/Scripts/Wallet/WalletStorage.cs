using System.Collections.Generic;
using UnityEngine;

public class WalletStorage
{
    private List<WalletItem> _walletItems = new List<WalletItem>();

    public List<WalletItem> WalletItems => _walletItems;

    public void Init()
    {
        _walletItems.Add(new WalletItem(WalletType.Coin, "Монеты", 0));
        _walletItems.Add(new WalletItem(WalletType.Diamond, "Алмазы", 0));
        _walletItems.Add(new WalletItem(WalletType.Energy, "Энергия", 0));
    }
}
