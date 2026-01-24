using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Jumper))]
[RequireComponent(typeof(CharacterAnimator))]
public class Player : BattleEntity
{
    [SerializeField] private Collector _collector;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private InputReader _inputReader;
    
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
}