using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpawner
{
    public class Elf : Enemy
    {
        [SerializeField] private List<ElfConfig> _config;

        public IReadOnlyList<ElfConfig> Config => _config;
    }
}
