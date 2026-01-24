using UnityEngine;

public class PigMovement : MonoBehaviour 
{
    [SerializeField] private Transform _waypoint;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private Transform _target;
    [SerializeField] private PatrolDetector _detector;

    private bool _isEnemyDetected = false;

    private void OnEnable()
    {
        _detector.PlayerDetected += SwitchDetectedStatus;
    }

    private void OnDisable()
    {
        _detector.PlayerDetected -= SwitchDetectedStatus;
    }

    public void SwitchDetectedStatus(bool status)
    {
        _isEnemyDetected = status;
    }

    public void ChangeMovementType(Transform waypoint, bool status)
    {
        SwitchDetectedStatus(status);

        _waypoint = waypoint;
    }

    public void HandleMovement()
    {
        if (_isEnemyDetected)
        {
            MoveStalking();
        }
        else
        {
            MovePatrol();
        }
    }

    private void MovePatrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, _waypoint.position, _speed * Time.deltaTime);      
    }

    private void MoveStalking()
    {
        bool shouldFaceRight = _target.position.x > transform.position.x;

        if (shouldFaceRight != _flipper.IsFacingRight)
        {
            _flipper.Flip(shouldFaceRight);
        }

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
