using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnemySpawner
{
    public class EnemySpawner : MonoBehaviour
    {
        public void Spawn(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                switch (enemy)
                {
                    case Ork ork:
                        OrkPrefab orkPrefab = ork.Config.FirstOrDefault(config => config.Prefab).Prefab;

                        if (orkPrefab != null)
                            for (int i = 0; i < ork.Config.Count; i++)
                                Instantiate(orkPrefab, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
                        break;

                    case Elf elf:
                        ElfPrefab elfPrefab = elf.Config.FirstOrDefault(config => config.Prefab).Prefab;

                        if (elfPrefab != null)
                            for (int i = 0; i < elf.Config.Count; i++)
                                Instantiate(elfPrefab, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
                        break;

                    case Dragon dragon:
                        DragonPrefab dragonPrefab = dragon.Config.FirstOrDefault(config => config.Prefab).Prefab;

                        if (dragonPrefab != null)
                            for (int i = 0; i < dragon.Config.Count; i++)
                                Instantiate(dragonPrefab, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
                        break;
                }
            }
        }
    }
}
