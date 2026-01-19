using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnemySpawner
{
    public class SpawnerExample : MonoBehaviour
    {
        [SerializeField] private EnemySpawner _enemySpawner;

        [SerializeField] private Ork _ork;
        [SerializeField] private Elf _elf;
        [SerializeField] private Dragon _dragon;

        private List<Enemy> _enemies;

        private void Awake()
        {
            _enemies = new List<Enemy>()
            {
                _ork,
                _elf,
                _dragon
            };
        }

        private void Start()
        {
            _enemySpawner.Spawn(_enemies);
        }
    }
}
