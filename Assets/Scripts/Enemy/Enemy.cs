using UnityEngine;

public class Enemy : BattleEntity
{
    [SerializeField] private PigMovement _pigMovement;
    [SerializeField] private PatrolDetector _patrolDetector;

    private void FixedUpdate()
    {
        _pigMovement.HandleMovement();
    }

    private void Update()
    {
        _patrolDetector.AttemptPlayerDetection();
    }
}
