using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDestroyer
{
    private Dictionary<Enemy, Func<bool>> _enemies = new();

    public Dictionary<Enemy, Func<bool>> Enemies => _enemies;

    public void AddEnemy(Enemy enemy, Func<bool> conditions) => _enemies.Add(enemy, conditions);
    public void RemoveEnemy(Enemy enemy) => _enemies.Remove(enemy);

    public void Update()
    {
        foreach (KeyValuePair<Enemy, Func<bool>> pair in _enemies.ToList())
        {
            Enemy enemy = pair.Key;
            Func<bool> condition = pair.Value;

            if (condition() == true)
            {
                RemoveEnemy(enemy);
                enemy.Destroy();
            }
        }
    }
}
