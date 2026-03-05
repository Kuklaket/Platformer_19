using UnityEngine;

public class RaycastPerformer : MonoBehaviour
{
    [SerializeField] private float _rayDistance = 2f;

    public bool TryGetDamageable(Vector2 direction, LayerMask targetLayer, out IDamageable damageable)
    {
        damageable = null;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _rayDistance, targetLayer);

        if (hit.collider != null)
        {
            damageable = hit.collider.GetComponent<IDamageable>();
            return damageable != null;
        }

        return false;
    }
}
