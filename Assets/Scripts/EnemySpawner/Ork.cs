using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpawner
{
    public class Ork : Enemy
    {
        [SerializeField] private List<OrkConfig> _config;

        public IReadOnlyList<OrkConfig> Config => _config;

        [Serializable]
        public class OrkConfig
        {
            [field: SerializeField] public OrkPrefab Prefab { get; private set; }
            [field: SerializeField] public int Health { get; private set; }
            [field: SerializeField] public int Damage { get; private set; }
            [field: SerializeField] public float MoveSpeed { get; private set; }
            [field: SerializeField] public int Strength { get; private set; }
        }
    }
}
