using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }
    private TowerData _towerToPlace;
    public bool IsInPlacementMode => _towerToPlace != null;
    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this;
    }

    public void EnterPlacementMode(TowerData tower)
    {
        _towerToPlace = tower;
    }

    public void PlaceTowerOn(TowerSpot spot)
    {
        if (_towerToPlace == null)
        {
            
            return;
        }

        spot.BuildTower(_towerToPlace.TowerPrefab);
        _towerToPlace = null; 
    }
}