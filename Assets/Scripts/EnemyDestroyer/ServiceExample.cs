using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ServiceExample : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private int _maxCountInService;
    [SerializeField] private int _timeToDestroyEnemy;

    private EnemyDestroyer _enemyDestroyer;

    private Enemy _enemy;

    private void Awake()
    {
        _enemyDestroyer = new EnemyDestroyer();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            float time = Time.time;

            _enemyDestroyer.AddEnemy(Instantiate(_enemyPrefab),
                () => Time.time - time > _timeToDestroyEnemy);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            _enemy = Instantiate(_enemyPrefab);
            _enemyDestroyer.AddEnemy(_enemy,
                () => _enemy.IsDead);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _enemyDestroyer.AddEnemy(Instantiate(_enemyPrefab),
                () => _enemyDestroyer.Enemies.Count > _maxCountInService);
        }

        if (Input.GetKeyDown(KeyCode.S))
            if (_enemy != null)
                _enemy.SetDead();
    }

    private void LateUpdate()
    {
        foreach (KeyValuePair<Enemy, Func<bool>> pair in _enemyDestroyer.Enemies.ToList())
        {
            Enemy enemy = pair.Key;
            Func<bool> condition = pair.Value;

            if (condition() == true)
            {
                _enemyDestroyer.RemoveEnemy(enemy);
                Destroy(enemy.gameObject);
            }
        }
    }
}
