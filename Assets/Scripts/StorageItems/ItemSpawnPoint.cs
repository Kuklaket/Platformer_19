using System;
using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour
{
    [SerializeField] private CollectibleItem _itemPrefab;

    private bool _hasItem = false;

    public CollectibleItem ItemPrefab { get => _itemPrefab; private set => _itemPrefab = value; }
    public bool HasItem => _hasItem;

    public event Action<CollectibleItem> ItemSpawned;

    public void SpawnItem()
    {
        if (ItemPrefab.TryGetComponent(out Coin coin))
        {
            Coin currentCoin = Instantiate(coin, transform.position, Quaternion.identity);
            ItemSpawned?.Invoke(currentCoin);
        }
        else if (ItemPrefab.TryGetComponent(out Medkit medkid))
        {
            Medkit currentMedkid = Instantiate(medkid, transform.position, Quaternion.identity);
            ItemSpawned?.Invoke(currentMedkid);
        }

        _hasItem = true;
    }

    public void SwitchStatus()
    {
        _hasItem = false;
    }
}