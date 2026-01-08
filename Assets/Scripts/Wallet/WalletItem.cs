using UnityEngine;

public class WalletItem
{
    private WalletType _walletType;
    private string _name;
    private int _value;

    public WalletType WalletType => _walletType;
    public int Value => _value;

    public WalletItem(WalletType walletType, string name, int value)
    {
        _walletType = walletType;
        _name = name;
    }

    public void AddValue(int value) => _value += value;

    public void RemoveValue(int value) => _value -= value;

    public void GetInfo()
    {
        Debug.Log($"{_name}: {_value}");
    }
}
