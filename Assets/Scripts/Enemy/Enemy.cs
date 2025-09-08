using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyData _enemyData;

    private EnemyMovement _enemyMovement;
    private int _currentHealth;

    
    public EnemyData EnemyData => _enemyData;

    public void Initialize(Path path) 
    {
        _enemyMovement = GetComponent<EnemyMovement>();
        _currentHealth = _enemyData.Health;
        _enemyMovement.Initialize(path, _enemyData.MoveSpeed);
    }

    public void TakeDamage(int amount)
    {
        _currentHealth -= amount;
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddCurrency(EnemyData.KillReward);
            GameManager.Instance.OnEnemyDestroyed(); 
        }
        Destroy(gameObject);
    }
}