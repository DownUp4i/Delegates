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
    }
}
