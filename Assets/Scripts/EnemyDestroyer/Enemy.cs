using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool _isDead;
    public bool IsDead => _isDead;

    public void SetDead() => _isDead = true;
}
