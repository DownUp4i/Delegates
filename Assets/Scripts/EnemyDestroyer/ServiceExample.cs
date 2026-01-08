using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceExample : MonoBehaviour
{
    [SerializeField] private int _maxCountInService;
    private float _time;

    private EnemyDestroyer _enemyDestroyer;

    private void Awake()
    {
        _enemyDestroyer = new EnemyDestroyer();
    }

    private void Start()
    {
        //_enemyDestroyer.AddEnemy(enemy, new List<Func<bool>>
        //{
        //    () => Time.time - time >= 5,
        //    () => enemy.IsDead == true,
        //    () => _enemyDestroyer.Enemies.Count > _maxCountInService,
        //});
    }

    private void Update()
    {
        _time = Time.time;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _enemyDestroyer.AddEnemy(new Enemy(), new List<Func<bool>>
            {
                () => Time.time - _time >= 5,
            });
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Enemy enemy = new Enemy();
            enemy.SetDead();
            _enemyDestroyer.AddEnemy(enemy, new List<Func<bool>>
            {
                () => enemy.IsDead,
            });
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            _enemyDestroyer.AddEnemy(new Enemy(), new List<Func<bool>>
            {
                () => _enemyDestroyer.Enemies.Count < _maxCountInService,
            });
        }

        Debug.Log(_enemyDestroyer.Enemies.Count);
    }
}
