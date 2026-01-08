using System;
using System.Collections.Generic;
using UnityEngine;

public class WalletHandler : MonoBehaviour
{
    private Wallet _wallet;

    public event Action<WalletType, int> OnAddValue;
    public event Action<WalletType, int> OnRemoveValue;

    private void Awake()
    {
        _wallet = new Wallet();
        _wallet.InitStorage();

        OnAddValue += _wallet.OnAddValue;
        OnRemoveValue += _wallet.OnRemoveValue;
    }

    public List<WalletItem> GetWalletItems() => _wallet.GetWalletItems();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            OnAddValue?.Invoke(WalletType.Coin, 100);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            OnRemoveValue?.Invoke(WalletType.Coin, 100);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            OnAddValue?.Invoke(WalletType.Diamond, 100);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            OnRemoveValue?.Invoke(WalletType.Diamond, 100);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            OnAddValue?.Invoke(WalletType.Energy, 100);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            OnRemoveValue?.Invoke(WalletType.Energy, 100);
    }

    private void OnDestroy()
    {
        OnAddValue -= _wallet.OnAddValue;
        OnRemoveValue -= _wallet.OnRemoveValue;
    }
}
