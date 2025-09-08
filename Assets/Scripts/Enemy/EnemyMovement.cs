using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Path _path;
    private int _currentWaypointIndex = 0;
    private float _moveSpeed;

    void Update()
    {
        if (_path == null) return;
        MoveAlongPath();
    }

    public void Initialize(Path path, float moveSpeed)
    {
        _path = path;
        _moveSpeed = moveSpeed;
    }

    private void MoveAlongPath()
    {
        if (_currentWaypointIndex >= _path.waypoints.Length)
        {
            ReachTheEnd();
            return;
        }

        Vector3 targetPosition = _path.waypoints[_currentWaypointIndex].position;
        float delta = _moveSpeed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, delta);

        
        transform.LookAt(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            _currentWaypointIndex++;
        }
    }

    private void ReachTheEnd()
    {
        if (PlayerBase.Instance != null)
        {
            PlayerBase.Instance.TakeDamage(GetComponent<Enemy>().EnemyData.Damage);
        }
        GameManager.Instance.OnEnemyDestroyed();
        Destroy(gameObject);
    }
}