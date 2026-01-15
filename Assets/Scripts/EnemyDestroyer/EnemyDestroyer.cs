using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyDestroyer
{
    private Dictionary<Enemy, Func<bool>> _enemies = new();

    public Dictionary<Enemy, Func<bool>> Enemies => _enemies;

    public void AddEnemy(Enemy enemy, Func<bool> conditions) => _enemies.Add(enemy, conditions);
    public void RemoveEnemy(Enemy enemy) => _enemies.Remove(enemy);
}
