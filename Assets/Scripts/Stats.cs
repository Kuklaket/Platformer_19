using System.Collections;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Stats : MonoBehaviour
{
    [SerializeField] private int _attack;
    [SerializeField] private int _cooldown;

    private bool _canAttack = true;

    public int Attack { get => _attack; private set => _attack = value; }
    public int Cooldown { get => _cooldown; private set => _cooldown = value; }
    public bool CanAttack { get => _canAttack; private set => _canAttack = value; }

    public void StartAttackCooldown()
    {
        StartCoroutine(AttackCooldownRoutine());
    }

    private IEnumerator AttackCooldownRoutine()
    {
        CanAttack = false;
        yield return new WaitForSeconds(_cooldown);
        CanAttack = true;
    }
}
