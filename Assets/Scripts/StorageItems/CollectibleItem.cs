using System;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public event Action<CollectibleItem> Collected;

    public void Collect()
    {
        Collected?.Invoke(this);
        Destroy(gameObject);
    }
}
