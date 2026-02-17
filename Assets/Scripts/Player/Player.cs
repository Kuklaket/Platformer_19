using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(PlayerAnimator))]
public class Player : BattleEntity
{
    [SerializeField] private Collector _collector;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerAttackHandler _playerAttackHandler;
    [SerializeField] private PlayerAnimator _playerAnimator;

    protected override void OnEnable()
    {
        base.OnEnable();
        _playerAttackHandler.AttackStarted += RunAttackAnimation;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _playerAttackHandler.AttackStarted -= RunAttackAnimation;
    }

    private void Update()
    {
        _groundDetector.CheckGrounded();
        _inputReader.HandleMovementInput();
        _inputReader.HandleJumpInput();
        _inputReader.HandleAttackInput();
    }

    public void Heal(int healthCount)
    {
        HealthSystem.AddHealth(healthCount);
    }

    private void RunAttackAnimation()
    {
        _playerAnimator.PlayAttack();
    }
}