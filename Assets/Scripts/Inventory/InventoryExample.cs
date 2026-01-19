using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryExample : MonoBehaviour
{
    private Inventory _inventory;
    private int _maxSize = 30;

    private Dictionary<Item, int> _inventoryList;

    Item _sword;
    Item _shield;
    Item _staff;

    private void Awake()
    {
        _sword = new Item("Sword");
        _shield = new Item("Shield");
        _staff = new Item("Staff");

        _inventoryList = new Dictionary<Item, int>
            {
            };

        _inventory = new Inventory(_inventoryList, _maxSize);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            _inventory.TryAdd(_sword, 1);
            GetInfo();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _inventory.TryAdd(_shield, 1);
            GetInfo();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            _inventory.TryAdd(_staff, 10);
            GetInfo();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            _inventory.GetItemsBy("Sword", 3);
            GetInfo();
        }
    }

    private void GetInfo()
    {
        Debug.Log($"Заполнено: {_inventory.CurrentSize}/{_maxSize}");

        foreach (KeyValuePair<Item, int> item in _inventory.Items)
            Debug.Log($"{item.Key.Name}: {item.Value}");
    }
}

