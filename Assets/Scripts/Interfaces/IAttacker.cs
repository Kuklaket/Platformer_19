public interface IAttacker
{
    int Damage { get; }
    bool CanAttack { get; }
    void StartAttackCooldown();
}
