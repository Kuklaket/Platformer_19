using System;
using System.Collections;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    [SerializeField] protected LayerMask TargetLayerMask;
    [SerializeField] protected float DamageDelay = 0.3f;

    protected BattleEntity Owner;
    protected Stats OwnerStats;

    public event Action<BattleEntity, int> AttackLanded;

    protected virtual void Awake()
    {
        Owner = GetComponentInParent<BattleEntity>();
        OwnerStats = GetComponentInParent<Stats>();
    }

    protected void StartAttack()
    {
        if (OwnerStats != null && OwnerStats.CanAttack)
        {
            OwnerStats.StartAttackCooldown();
        }
    }

    protected void DealDamage(BattleEntity target)
    {
        if (target == null || Owner == null) return;

        int damage = Owner.Attack;
        target.HandleDamage(damage);
        AttackLanded?.Invoke(target, damage);
    }

    protected bool IsInTargetLayer(int layer)
    {
        return TargetLayerMask == (TargetLayerMask | (1 << layer));
    }

    protected IEnumerator PerformAttack(BattleEntity target)
    {
        yield return new WaitForSeconds(DamageDelay);
        DealDamage(target);
    }
}