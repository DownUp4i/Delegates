using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        public void Spawn(EnemyConfig enemyConfig)
        {
            switch (enemyConfig)
            {
                case DragonConfig dragon:
                    Instantiate(dragon.Prefab);
                    break;
                case OrkConfig ork:
                    Instantiate(ork.Prefab);
                    break;
                case ElfConfig elf:
                    Instantiate(elf.Prefab);
                    break;
            }
        }
    }
}
