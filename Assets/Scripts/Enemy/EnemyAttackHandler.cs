using System;
using UnityEngine;

public class EnemyAttackHandler : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private PigAnimator _pigAnimator;
    [SerializeField] private Collider2D _takeDamageCollider;
    [SerializeField] private LayerMask _targetLayerMask = 8; 

    private int _layerMaskNumber = 1;

    public event Action<BattleEntity, int> PlayerAttacked;
    public event Action AttackStarted;

    private void Start()
    {
        if (_takeDamageCollider != null)
        {
            _takeDamageCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((_layerMaskNumber << collision.gameObject.layer) & _targetLayerMask) != 0)
        {           
            if (collision.gameObject.TryGetComponent<Player>(out Player player))
            {
                TryAttack(player);
            }
        }
    }

    private void TryAttack(Player player)
    {
        if (_enemy == null)
        {
            return;
        }

        if (_enemy.TryGetComponent<Stats>(out Stats stats))
        {
            if (stats.CanAttack)
            {
                AttackHandler(player);
                stats.StartAttackCooldown();
            }
        }
    }

    private void AttackHandler(Player player)
    {
        if (player == null)
        {
            return;
        }

        TakeDamage(player, _enemy.GetAttack());
        _pigAnimator.PlayAttack();
    }

    private void TakeDamage(BattleEntity attackTarget, int damage)
    {
        attackTarget.HandlerDamage(damage);
    }
}