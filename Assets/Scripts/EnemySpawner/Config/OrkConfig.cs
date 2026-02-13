using System;
using System.Collections;
using System.Collections.Generic;
using EnemySpawner;
using UnityEngine;

namespace EnemySpawner
{
    [Serializable]
    public class OrkConfig : EnemyConfig
    {
        [field: SerializeField] public Ork Prefab { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public int Strength { get; private set; }
    }
}
