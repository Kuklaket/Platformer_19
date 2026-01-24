using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private float _rayDistance;

    public bool CheckRayHit(Vector2 direction, LayerMask targetLayer, out BattleEntity battleEntity)
    {
        battleEntity = null;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, _rayDistance, targetLayer);

        if (hit.collider?.TryGetComponent<BattleEntity>(out battleEntity) == true)
        {
            return true;
        }

        return false;
    }
}
