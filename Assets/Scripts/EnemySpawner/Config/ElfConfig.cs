using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySpawner
{
    [Serializable]

    public class ElfConfig : MonoBehaviour
    {
        [field: SerializeField] public Elf Prefab { get; private set; }
        [field: SerializeField] public int Health { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public int Agility { get; private set; }
    }
}

