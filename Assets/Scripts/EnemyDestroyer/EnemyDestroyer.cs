using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyer
{
    private Dictionary<List<Func<bool>>, Enemy> _enemies = new();

    public Dictionary<List<Func<bool>>, Enemy> Enemies => _enemies;

    public void AddEnemy(Enemy enemy, List<Func<bool>> conditions) => _enemies.Add(conditions, enemy);
    public void RemoveEnemy(List<Func<bool>> conditions) => _enemies.Remove(conditions);
}
