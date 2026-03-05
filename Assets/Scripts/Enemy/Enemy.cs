using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private PigMovement _mover;
    [SerializeField] private PatrolDetector _patrolDetector;
    [SerializeField] private EnemyAnimator _animator;
    [SerializeField] private Collider2D _attackTrigger;

    private IDamageable _currentTarget;

    protected override void Awake()
    {
        base.Awake();

        if (_attackTrigger != null)
        {
            _attackTrigger.isTrigger = true;
        }
    }

    private void FixedUpdate()
    {
        _mover?.HandleMovement();
    }

    private void Update()
    {
        _patrolDetector?.AttemptPlayerDetection();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!CanAttackTarget(collision)) return;

        if (collision.TryGetComponent<IDamageable>(out IDamageable target))
        {
            _currentTarget = target;

            if (CanPerformAttack())
            {
                _animator?.PlayAttack();
                PerformAttack(_currentTarget);
            }
        }
    }

    private bool CanAttackTarget(Collider2D collision)
    {
        return _attacker != null && _attacker.IsInTargetLayer(collision.gameObject.layer);
    }
}