using System;
using UnityEngine;

public abstract class Character : MonoBehaviour, IAttacker, IDamageable
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _attackCooldown;

    protected HealthSystem _healthSystem;
    protected Attacker _attacker;
    protected bool _canAttack = true;
    protected Coroutine _cooldownCoroutine;

    public int Damage => _damage;
    public bool CanAttack => _canAttack;

    public event Action AttackStarted;

    protected virtual void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _attacker = GetComponentInChildren<Attacker>();

        if (_attacker != null)
            _attacker.Owner = this;
    }

    protected virtual void OnEnable()
    {
        if (_healthSystem != null)
            _healthSystem.Died += Die;
    }

    protected virtual void OnDisable()
    {
        if (_healthSystem != null)
            _healthSystem.Died -= Die;
    }

    public virtual void TakeDamage(int damageCount)
    {
        _healthSystem?.TakeDamage(damageCount);
    }

    public void Heal(int healthCount)
    {
        _healthSystem?.AddHealth(healthCount);
    }

    public void StartAttackCooldown()
    {
        if (_cooldownCoroutine != null)
            StopCoroutine(_cooldownCoroutine);

        _cooldownCoroutine = StartCoroutine(AttackCooldownRoutine());
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }

    protected virtual bool CanPerformAttack()
    {
        return _canAttack && _attacker != null;
    }

    protected virtual void PerformAttack(IDamageable target)
    {
        if (!CanPerformAttack()) return;

        AttackStarted?.Invoke();
        _attacker.StartAttack();
        StartCoroutine(_attacker.PerformAttack(target));
    }

    private System.Collections.IEnumerator AttackCooldownRoutine()
    {
        _canAttack = false;
        yield return new WaitForSeconds(_attackCooldown);
        _canAttack = true;
        _cooldownCoroutine = null;
    }
}

