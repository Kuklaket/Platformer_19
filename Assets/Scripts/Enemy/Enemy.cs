using UnityEngine;

public class Enemy : BattleEntity
{
    [SerializeField] private PigMovement _mover;
    [SerializeField] private PatrolDetector _patrolDetector;
    [SerializeField] private EnemyAttackHandler _attackHandler;
    [SerializeField] private EnemyAnimator _animator;

    protected override void OnEnable()
    {
        base.OnEnable();
        _attackHandler.AttackStarted += RunAttackAnimation;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _attackHandler.AttackStarted -= RunAttackAnimation;
    }

    private void FixedUpdate()
    {
        _mover.HandleMovement();
    }

    private void Update()
    {
        _patrolDetector.AttemptPlayerDetection();
    }

    private void RunAttackAnimation()
    {
        _animator.PlayAttack();
    }
}
