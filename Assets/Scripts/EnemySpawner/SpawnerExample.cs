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

        [SerializeField] private OrkConfig _ork;
        [SerializeField] private ElfConfig _elf;
        [SerializeField] private DragonConfig _dragon;

        private List<EnemyConfig> _enemies;

        private void Awake()
        {
            _enemies = new List<EnemyConfig>()
            {
                _ork,
                _elf,
                _dragon
            };
        }

        private void Start()
        {
            _enemySpawner.Spawn(_ork);
        }
    }
}
