using UnityEngine;

public class TowerSpot : MonoBehaviour
{
    private GameObject _placedTower;

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsGameOver) return;

        if (_placedTower != null)
        {
            Debug.Log("Spot is already occupied.");
            return;
        }

        BuildManager.Instance.PlaceTowerOn(this);
    }

    public void BuildTower(GameObject towerPrefab)
    {
        if (towerPrefab == null)
        {
            Debug.LogError("Tower Prefab is missing! Check your TowerData asset.");
            return;
        }

        _placedTower = Instantiate(towerPrefab, transform.position, Quaternion.identity);
        GameManager.Instance.RecordTowerPurchase(); 
        GetComponent<MeshRenderer>().enabled = false;
        Debug.Log("Tower Placed!"); 
    }
}