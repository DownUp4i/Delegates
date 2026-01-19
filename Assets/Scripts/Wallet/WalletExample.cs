using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private WalletUI _walletUIPrefab;
    [SerializeField] private int _amountToAdd = 100;
    [SerializeField] private int _amountToRemove = 100;

    private Wallet _wallet;
    private WalletUI _walletUI;

    private bool _isInstance;

    private ReactiveVariable<int> _coin;
    private ReactiveVariable<int> _diamond;
    private ReactiveVariable<int> _energy;

    private void Awake()
    {
        _isInstance = false;

        _coin = new ReactiveVariable<int>(0);
        _diamond = new ReactiveVariable<int>(0);
        _energy = new ReactiveVariable<int>(0);

        Dictionary<CoinType, ReactiveVariable<int>> _startWallet = new Dictionary<CoinType, ReactiveVariable<int>>
        {
            { CoinType.Coin, _coin},
            { CoinType.Energy, _diamond },
            { CoinType.Diamond, _energy }
        };

        _wallet = new Wallet(_startWallet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (_isInstance == false)
            {
                _isInstance = true;
                _walletUI = Instantiate(_walletUIPrefab);
                _walletUI.Init(_wallet);
            }
            else
            {
                _isInstance = false;
                Destroy(_walletUI.gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
            _wallet.AddValue(CoinType.Coin, _amountToAdd);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _wallet.RemoveValue(CoinType.Coin, _amountToRemove);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _wallet.AddValue(CoinType.Diamond, _amountToAdd);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            _wallet.RemoveValue(CoinType.Diamond, _amountToRemove);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            _wallet.AddValue(CoinType.Energy, _amountToAdd);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            _wallet.RemoveValue(CoinType.Energy, _amountToRemove);
    }
}
