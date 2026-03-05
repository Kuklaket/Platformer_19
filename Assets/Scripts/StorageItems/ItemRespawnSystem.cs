using System.Collections.Generic;
using UnityEngine;

public class ItemRespawnSystem : MonoBehaviour
{
    [SerializeField] private List<ItemRespawnPoint> _coinSpawnPoints = new();
    [SerializeField] private List<ItemRespawnPoint> _medkitSpawnPoints = new();
    [SerializeField] private Coin _coin;
    [SerializeField] private Medkit _medkit;

    private CollectibleItem _currentItem;

    private void Start()
    {
        SpawnItems(_coin);
        SpawnItems(_medkit);
    }

    public void SpawnItems(CollectibleItem collectedItem)
    {
        List<ItemRespawnPoint> spawnPoints = GetSpawnPointsForItem(collectedItem);

        if (spawnPoints != null && spawnPoints.Count > 0)
        {
            List<ItemRespawnPoint> availablePoints = new List<ItemRespawnPoint>();

            foreach (ItemRespawnPoint point in spawnPoints)
            {
                if (point.HasItem)
                {
                    point.SwitchStatus();
                }
                else
                {
                    availablePoints.Add(point);
                }
            }

            if (availablePoints.Count > 0)
            {
                int spawnPointNumber = Random.Range(0, availablePoints.Count);
                availablePoints[spawnPointNumber].SpawnItem();
            }
        }
    }

    private void HandleItemCollected(CollectibleItem item)
    {
        SpawnItems(item);
        HandleItemSpawned(item);
    }

    private void HandleItemSpawned(CollectibleItem newItem)
    {
        if (_currentItem != null)
        {
            _currentItem.Collected -= HandleItemCollected;
        }

        _currentItem = newItem;
        _currentItem.Collected += HandleItemCollected;
    }

    private List<ItemRespawnPoint> GetSpawnPointsForItem(CollectibleItem item)
    {
        if (item is Medkit) return _medkitSpawnPoints;
        if (item is Coin) return _coinSpawnPoints;
        return null;
    }
}