using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpawner
{
    public class Elf : Enemy
    {
        [SerializeField] private List<ElfCongig> _config;

        public IReadOnlyList<ElfCongig> Config => _config;

        [Serializable]
        public class ElfCongig
        {
            [field: SerializeField] public ElfPrefab Prefab { get; private set; }
            [field: SerializeField] public int Health { get; private set; }
            [field: SerializeField] public int Damage { get; private set; }
            [field: SerializeField] public float MoveSpeed { get; private set; }
            [field: SerializeField] public int Agility { get; private set; }
        }
    }
}
