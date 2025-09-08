using UnityEngine;

[System.Serializable]
public class WaveStep
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private int _count = 1;
    [SerializeField][Range(0.1f, 5f)] private float _spawnInterval = 1f;

    public GameObject EnemyPrefab => _enemyPrefab;
    public int Count => _count;
    public float SpawnInterval => _spawnInterval;
}

[CreateAssetMenu(fileName = "New Wave Data", menuName = "Data/Wave")]
public class WaveData : ScriptableObject
{
    [SerializeField] private WaveStep[] _waveSteps;

    

    public WaveStep[] WaveSteps => _waveSteps;
    
}