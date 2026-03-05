using System;
using UnityEngine;

public class ItemRespawnPoint : MonoBehaviour
{
    [SerializeField] private CollectibleItem _itemPrefab;

    private bool _hasItem = false;

    public CollectibleItem ItemPrefab { get => _itemPrefab; private set => _itemPrefab = value; }
    public bool HasItem => _hasItem;

    public event Action<CollectibleItem> ItemSpawned;

    public void SpawnItem()
    {
        CollectibleItem newItem = Instantiate(ItemPrefab, transform.position, Quaternion.identity);
        ItemSpawned?.Invoke(newItem);
        _hasItem = true;
    }

    public void SwitchStatus()
    {
        _hasItem = false;
    }
}