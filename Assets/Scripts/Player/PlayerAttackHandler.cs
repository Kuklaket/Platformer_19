using System;
using UnityEngine;

public class PlayerAttackHandler: MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Player _player;
    [SerializeField] private CharacterAnimator _characterAnimator;
    [SerializeField] private RaycastHandler _raycastHandler;
    [SerializeField] private float _hitDelay = 0.3f;

    public event Action<BattleEntity,int> EnemyAttacked;

    private void Awake()
    {
        _characterAnimator = _player.GetComponent<CharacterAnimator>();
    }

    private void OnEnable()
    {
        _inputReader.AttackPressed += AttemptAttack;
    }

    private void OnDisable()
    {
        _inputReader.AttackPressed -= AttemptAttack;
    }

    private void AttemptAttack()
    {
        if (_player.TryGetComponent<Stats>(out Stats stats))
        {
            if (stats.CanAttack)
            {
                stats.StartAttackCooldown();
                ExecuteAttack();
            }
        }
    } 

    private void ExecuteAttack()
    {
        _characterAnimator?.PlayAttack();

        Invoke(nameof(HitEnemy), _hitDelay);
    }
    private void HitEnemy()
    {
        Vector2 direction = transform.right;

        if (_raycastHandler.CheckRayHit(direction, _targetLayer, out BattleEntity enemy))
        {
            TakeDamage(enemy, _player.GetAttack());
        }
    }

    private void TakeDamage(BattleEntity attackTarget, int damage)
    {
        attackTarget.HandlerDamage(damage);
        EnemyAttacked?.Invoke(attackTarget, damage);
    }
}