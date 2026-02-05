using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
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
                        Ork orkConfig = ork.Config.FirstOrDefault(config => config.Prefab).Prefab;

                        if (orkConfig != null)
                            for (int i = 0; i < ork.Config.Count; i++)
                                Instantiate(orkConfig, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
                        break;

                    case Elf elf:
                        Elf elfConfig = elf.Config.FirstOrDefault(config => config.Prefab).Prefab;

                        if (elfConfig != null)
                            for (int i = 0; i < elf.Config.Count; i++)
                                Instantiate(elfConfig, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
                        break;

                    case Dragon dragon:
                        Dragon dragonConfig = dragon.Config.FirstOrDefault(config => config.Prefab).Prefab;

                        if (dragonConfig != null)
                            for (int i = 0; i < dragon.Config.Count; i++)
                                Instantiate(dragonConfig, new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5)), Quaternion.identity);
                        break;
                }
            }
        }
    }
}
