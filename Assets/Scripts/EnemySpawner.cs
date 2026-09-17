using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private WaveConfigSO[] waveConfigs;
    [SerializeField] private WaveConfigSO currentWave;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] private bool isLooping;
    void Start()
    {
        
       StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(
                        currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.identity,
                        transform
                    );

                    yield return new WaitForSeconds(
                        currentWave.GetRandomEnemySpawnTime()
                    );
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
        
        
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
