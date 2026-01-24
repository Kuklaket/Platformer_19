using UnityEngine;

public class Medkit : CollectibleItem
{
    [SerializeField] private int _healAmount = 25;

    public int HealAmount => _healAmount;
}
