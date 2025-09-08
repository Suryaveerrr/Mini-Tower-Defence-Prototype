using UnityEngine;

[RequireComponent(typeof(AudioSource))] 
public class Tower : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TowerData _towerData;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private AudioClip _fireSound;

    private Transform _target;
    private float _fireCountdown = 0f;
    private float _fireInterval;
    private AudioSource _audioSource; 

    private void Start()
    {
        _fireInterval = 1f / _towerData.FireRate;
        _audioSource = GetComponent<AudioSource>(); 
    }

    private void Update()
    {
        if (_target == null)
        {
            FindTarget();
        }
        else
        {
            if (Vector3.Distance(transform.position, _target.position) > _towerData.Range)
            {
                _target = null;
            }
            else
            {
                _fireCountdown -= Time.deltaTime;
                if (_fireCountdown <= 0f)
                {
                    Fire();
                    _fireCountdown = _fireInterval;
                }
            }
        }
    }

    private void Fire()
    {
        
        if (_fireSound != null)
        {
            _audioSource.PlayOneShot(_fireSound);
        }

        IDamageable damageable = _target.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(_towerData.Damage);
        }
    }

    private void FindTarget()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _towerData.Range, _enemyLayer);
        if (hitColliders.Length > 0)
        {
            _target = hitColliders[0].transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, _towerData != null ? _towerData.Range : 5f);
    }
}