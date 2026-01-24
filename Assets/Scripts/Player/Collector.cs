using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private Player _player;
    [SerializeField] private SpawnManager _spawnManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CollectibleItem item))
        {
            switch (item)
            {
                case Coin coin:
                    _coinsCounter.AddCoin();
                    break;

                case Medkit medkit:
                    _player.Heal(medkit.HealAmount);
                    break;
            }

            item.Collect();
            _spawnManager.SpawnItems(item);
        }
    }
}