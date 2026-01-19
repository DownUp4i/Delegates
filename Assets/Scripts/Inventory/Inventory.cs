
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using static UnityEditor.Progress;

public class Inventory
{
    private Dictionary<Item, int> _items = new Dictionary<Item, int>();

    private int _maxSize;
    private int _currentSize;

    public Inventory(Dictionary<Item, int> items, int maxSize)
    {
        _maxSize = maxSize;
        _currentSize = 0;

        foreach (KeyValuePair<Item, int> item in items)
            TryAdd(item.Key, item.Value);
    }

    public int CurrentSize => _items.Values.Sum(item => item);
    public IReadOnlyDictionary<Item, int> Items => _items;

    public bool TryAdd(Item item, int count)
    {
        if (count <= 0)
            throw new InventoryException("Количество должно быть больше 0", count);

        if (_currentSize + count > _maxSize)
            throw new InventoryException($"Невозможно добавить {count} кол-во: не хватает места в инвентаре, Заполнено: {_currentSize}/{_maxSize}");

        Add(item, count);

        return true;
    }

    public void Add(Item newItem, int count)
    {
        if (_items.ContainsKey(newItem))
            _items[newItem] += count;
        else
            _items.Add(newItem, count);
    }

    public Dictionary<Item, int> GetItemsBy(string name, int count)
    {
        Dictionary<Item, int> items = new Dictionary<Item, int>();

        if (TryGetItem(name, count))
            items.Add(new Item(name), count);

        return items;
    }

    public bool TryGetItem(string name, int count)
    {
        if (count <= 0)
            throw new InventoryException("Количество должно быть больше 0", count);

        foreach (Item item in _items.Keys.ToList())
        {
            if (item.Name == name)
            {
                if (_items[item] < count)
                    throw new InventoryException("Не хватает", count);
                else
                    _items[item] -= count;

                if (_items[item] <= 0)
                    _items.Remove(item);

                return true;
            }
        }
        return false;
    }
}
