using UnityEngine;

[System.Serializable]
public class WaveStep
{
    [Tooltip("The enemy prefab to spawn in this step.")]
    [SerializeField] private GameObject _enemyPrefab;

    [Tooltip("How many enemies of this type to spawn.")]
    [SerializeField] private int _count = 1;

    [Tooltip("The time delay between each enemy spawn in this step (for sequential spawning).")]
    [SerializeField][Range(0.1f, 5f)] private float _spawnInterval = 1f;

    
    public GameObject EnemyPrefab => _enemyPrefab;
    public int Count => _count;
    public float SpawnInterval => _spawnInterval;
}