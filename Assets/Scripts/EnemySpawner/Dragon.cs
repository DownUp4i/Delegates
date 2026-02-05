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

    }
}
