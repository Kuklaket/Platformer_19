using System;
using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayerMask;
    [SerializeField] private float _damageDelay = 0.3f;

    private int _singleBit = 1;

    public IAttacker Owner { get; set; }
    public LayerMask TargetLayerMask => _targetLayerMask;

    public event Action<IDamageable, int> AttackLanded;

    public void StartAttack()
    {
        if (Owner != null)
        {
            Owner.StartAttackCooldown();
        }
    }

    public void DealDamage(IDamageable target)
    {
        int damage = Owner.Damage;

        target.TakeDamage(damage);
        AttackLanded?.Invoke(target, damage);
    }

    public bool IsInTargetLayer(int layer)
    {
        bool result = (TargetLayerMask.value & (_singleBit << layer)) != 0;

        return result;
    }

    public IEnumerator PerformAttack(IDamageable target)
    {
        if (target == null) yield break;

        yield return new WaitForSeconds(_damageDelay);
        DealDamage(target);
    }
}