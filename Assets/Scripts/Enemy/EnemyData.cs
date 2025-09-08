using UnityEngine;


[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Data/Enemy")]
public class EnemyData : ScriptableObject
{
    [Header("Stats")]
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _health = 100;
    [SerializeField] private int _damage = 10;
    [SerializeField] private int _killReward = 50;

    public float MoveSpeed => _moveSpeed;
    public int Health => _health;
    public int Damage => _damage;
    public int KillReward => _killReward;
}