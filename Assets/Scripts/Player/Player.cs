using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerAnimator))]
[RequireComponent(typeof(HealthSystem))]
public class Player : Character
{
    [SerializeField] private Collector _collector;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private RaycastPerformer _raycastHandler;

    protected override void OnEnable()
    {
        base.OnEnable();

        _inputReader.AttackPressed += AttemptAttack;
    }

    protected override void OnDisable()
    {
        base.OnDisable();

        _inputReader.AttackPressed -= AttemptAttack;
    }

    private void Update()
    {
        _groundDetector.ValidateGroundedState();
    }

    public void AttemptAttack()
    {
        if (!_canAttack) return;

        PlayAttackAnimation();

        Vector2 direction = transform.right;

        if (_raycastHandler != null && _raycastHandler.TryGetDamageable(direction, _attacker.TargetLayerMask, out IDamageable target))
        {
            PerformAttack(target);
        }

        StartAttackCooldown();
    }

    private void PlayAttackAnimation()
    {
        _playerAnimator?.PlayAttack();
    }
}