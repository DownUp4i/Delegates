using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryException : System.Exception
{
    public int Count { get; }

    public InventoryException(string message, int count) : base(message)
    {
        Count = count;
    }

    public InventoryException(string message) : base(message)
    {
    }
}
