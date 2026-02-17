using System;
using UnityEngine;

public class EnemyAttackHandler : AttackSystem
{
    [SerializeField] private Collider2D _attackTrigger;

    private float _nextAttackTime;
    private BattleEntity _currentTarget;

    public event Action AttackStarted;

    protected override void Awake()
    {
        base.Awake();

        if (_attackTrigger != null)
        {
            _attackTrigger.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsInTargetLayer(collision.gameObject.layer)) return;

        if (collision.TryGetComponent<BattleEntity>(out var target))
        {
            _currentTarget = target;
            TryAttack(target);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!IsInTargetLayer(collision.gameObject.layer)) return;

        if (OwnerStats != null && !OwnerStats.CanAttack)
            return;

        if (collision.TryGetComponent<BattleEntity>(out var target))
        {
            _currentTarget = target;
            TryAttack(target);
        }
    }

    private void TryAttack(BattleEntity target)
    {
        if (OwnerStats != null && !OwnerStats.CanAttack)
            return;

        AttackStarted?.Invoke();
        StartAttack();
        StartCoroutine(PerformAttack(target));
    }
}