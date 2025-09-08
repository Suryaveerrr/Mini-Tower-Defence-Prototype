using UnityEngine;

[CreateAssetMenu(fileName = "New Tower Data", menuName = "Data/Tower")]
public class TowerData : ScriptableObject
{
    [Header("Info")]
    [SerializeField] private string _towerName;
    [SerializeField][TextArea] private string _description; 

    [Header("Visuals")]
    [SerializeField] private GameObject _towerPrefab;

    [Header("Stats")]
    [SerializeField] private int _cost = 100;
    [SerializeField] private int _damage = 20;
    [SerializeField][Range(0.1f, 5f)] private float _fireRate = 1f;
    [SerializeField][Range(1f, 20f)] private float _range = 5f;

    public string TowerName => _towerName;
    public string Description => _description; 
    public GameObject TowerPrefab => _towerPrefab;
    public int Cost => _cost;
    public int Damage => _damage;
    public float FireRate => _fireRate;
    public float Range => _range;
}