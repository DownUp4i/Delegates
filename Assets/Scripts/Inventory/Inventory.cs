
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

    public Inventory(Dictionary<Item, int> items, int maxSize)
    {
        _maxSize = maxSize;

        foreach (KeyValuePair<Item, int> item in items)
            TryAdd(item.Key, item.Value);
    }

    public int CurrentSize => _items.Values.Sum(item => item);
    public IReadOnlyDictionary<Item, int> Items => _items;

    public bool TryAdd(Item item, int count)
    {
        if (count <= 0)
            throw new InventoryException("count");

        if (CurrentSize + count > _maxSize)
            return false;

        Add(item, count);

        return true;
    }

    private void Add(Item newItem, int count)
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
            throw new InventoryException("count");

        foreach (Item item in _items.Keys.ToList())
        {
            if (item.Name == name)
            {
                if (_items[item] < count)
                    return false;
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
