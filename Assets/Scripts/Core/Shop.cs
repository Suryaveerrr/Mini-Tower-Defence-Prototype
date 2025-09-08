using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Tower Data")]
    [SerializeField] private TowerData _minigunTower;
    [SerializeField] private TowerData _m16Tower;
   

    public void BuyMinigunTower()
    {
        AttemptPurchase(_minigunTower);
    }

    public void BuyM16Tower()
    {
        AttemptPurchase(_m16Tower);
    }

    private void AttemptPurchase(TowerData tower)
    {
        if (GameManager.Instance.IsGameOver) return;

        if (GameManager.Instance.HasReachedTowerLimit)
        {
            Debug.Log("Tower limit reached! Cannot buy any more towers.");
            return;
        }

        if (BuildManager.Instance.IsInPlacementMode)
        {
            Debug.Log("You must place your current tower first!");
            return;
        }

        if (GameManager.Instance.SpendCurrency(tower.Cost))
        {
            Debug.Log($"Purchase successful! You bought a {tower.TowerName}.");
            BuildManager.Instance.EnterPlacementMode(tower);
        }
        else
        {
            Debug.Log($"Purchase failed. Not enough coins for {tower.TowerName}.");
        }
    }
}