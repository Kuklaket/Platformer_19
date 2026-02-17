using System;
using UnityEngine;

public class PlayerAttackHandler : AttackSystem
{
    [SerializeField] private RaycastHandler _raycastHandler;
    [SerializeField] private InputReader _inputReader;

    public event Action AttackStarted;

    private void OnEnable()
    {
        _inputReader.AttackPressed += AttemptAttack;
    }

    private void OnDisable()
    {
        _inputReader.AttackPressed -= AttemptAttack;
    }

    public void AttemptAttack()
    {
        if (OwnerStats != null && !OwnerStats.CanAttack)
            return;

        StartAttack();
        AttackStarted?.Invoke();

        Vector2 direction = transform.right;

        if (_raycastHandler.CheckRayHit(direction, TargetLayerMask, out BattleEntity target))
        {
            StartCoroutine(PerformAttack(target));
        }
    }
}