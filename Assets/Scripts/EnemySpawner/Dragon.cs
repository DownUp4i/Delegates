using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpawner
{
    public class Dragon : Enemy
    {
        [SerializeField] private List<DragonConfig> _dragonConfig;

        public IReadOnlyList<DragonConfig> Config => _dragonConfig;

        [Serializable]
        public class DragonConfig
        {
            [field: SerializeField] public DragonPrefab Prefab { get; private set; }
            [field: SerializeField] public int Health { get; private set; }
            [field: SerializeField] public int Damage { get; private set; }
            [field: SerializeField] public float FlySpeed { get; private set; }
        }
    }
}
