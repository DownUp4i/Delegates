using System;
using System.Collections;
using System.Collections.Generic;
using EnemySpawner;
using UnityEngine;

namespace EnemySpawner
{
    [Serializable]

    public class DragonConfig : EnemyConfig
    {
        [field: SerializeField] public Dragon Prefab { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float FlySpeed { get; private set; }
    }
}

