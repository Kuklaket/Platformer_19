using System;
using UnityEngine;

public class PatrolDetector : MonoBehaviour
{
    [SerializeField] private RaycastPerformer _raycastHandler;
    [SerializeField] private LayerMask _targetLayer;

    public event Action<bool> PlayerDetected;

    public void AttemptPlayerDetection()
    {
        Vector2 direction = transform.right;

        if (_raycastHandler.TryGetDamageable(direction, _targetLayer, out _))
        {
            PlayerDetected?.Invoke(true);
        }
    }
}
