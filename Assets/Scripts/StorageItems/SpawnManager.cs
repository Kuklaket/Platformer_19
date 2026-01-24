using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<ItemSpawnPoint> _coinSpawnPoints = new();
    [SerializeField] private List<ItemSpawnPoint> _medkitSpawnPoints = new();
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
        List<ItemSpawnPoint> spawnPoints = GetSpawnPointsForItem(collectedItem);

        if (spawnPoints != null && spawnPoints.Count > 0)
        {
            List<ItemSpawnPoint> availablePoints = new List<ItemSpawnPoint>();

            foreach (ItemSpawnPoint point in spawnPoints)
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

    private List<ItemSpawnPoint> GetSpawnPointsForItem(CollectibleItem item)
    {
        if (item is Medkit) return _medkitSpawnPoints;
        if (item is Coin) return _coinSpawnPoints;
        return null;
    }
}