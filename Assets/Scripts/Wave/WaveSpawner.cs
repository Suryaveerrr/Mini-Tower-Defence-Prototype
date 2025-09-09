using UnityEngine;
using System.Collections;
using System;

public class WaveSpawner : MonoBehaviour
{
    
    [SerializeField] private Path _path;

    public IEnumerator SpawnWave(WaveData wave, Action onEnemySpawned, Action onWaveCompleted)
    {
        foreach (WaveStep step in wave.WaveSteps)
        {
            for (int i = 0; i < step.Count; i++)
            {
                GameObject enemyInstance = Instantiate(step.EnemyPrefab, transform.position, Quaternion.identity);

                
                enemyInstance.GetComponent<Enemy>().Initialize(_path);

                onEnemySpawned?.Invoke();
                yield return new WaitForSeconds(step.SpawnInterval);
            }
        }
        onWaveCompleted?.Invoke();
    }
}