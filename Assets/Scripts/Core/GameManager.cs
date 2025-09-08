using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static event Action<int> OnCurrencyChanged;
    public static event Action<int, int> OnWaveChanged;

    [SerializeField] private WaveSpawner _waveSpawner;
    [SerializeField] private WaveData[] _allWaves;

    public int Currency { get; private set; }
    public bool IsGameOver { get; private set; } = false;

    private int _currentWaveIndex = 0;
    private int _enemiesAlive = 0;
    private bool _isSpawning = false;

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    private void Start()
    {
        StartNextWave();
    }

    private void Update()
    {
        if (!_isSpawning && _enemiesAlive == 0 && _currentWaveIndex == _allWaves.Length && !IsGameOver)
        {
            WinGame();
        }
    }

    public void StartNextWave()
    {
        if (_currentWaveIndex >= _allWaves.Length || IsGameOver) return;

        UIManager.Instance.SetNextWaveButtonActive(false);
        OnWaveChanged?.Invoke(_currentWaveIndex + 1, _allWaves.Length);

        WaveData nextWave = _allWaves[_currentWaveIndex];
        StartCoroutine(_waveSpawner.SpawnWave(nextWave, OnEnemySpawned, OnWaveCompleted));

        _isSpawning = true;
        _currentWaveIndex++;
    }

    public void OnEnemySpawned()
    {
        _enemiesAlive++;
    }

    public void OnEnemyDestroyed()
    {
        _enemiesAlive--;

        if (!_isSpawning && _enemiesAlive == 0 && !IsGameOver)
        {
            if (_currentWaveIndex < _allWaves.Length)
            {
                UIManager.Instance.SetNextWaveButtonActive(true);
            }
        }
    }

    public void OnWaveCompleted()
    {
        _isSpawning = false;
    }

    private void WinGame()
    {
        IsGameOver = true;
        UIManager.Instance.ShowWinScreen();
    }

    public void EndGame()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        Time.timeScale = 0f;
        UIManager.Instance.ShowGameOverScreen();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
    public int TowerLimit { get; } = 10;
    public int TowersPurchasedCount { get; private set; } = 0;
    public bool HasReachedTowerLimit => TowersPurchasedCount >= TowerLimit;

    public void AddCurrency(int amount)
    {
        Currency += amount;
        OnCurrencyChanged?.Invoke(Currency);
    }

    public bool SpendCurrency(int amount)
    {
        if (amount <= Currency)
        {
            Currency -= amount;
            OnCurrencyChanged?.Invoke(Currency);
            return true;
        }
        return false;
    }

    public void RecordTowerPurchase()
    {
        TowersPurchasedCount++;
    }
}