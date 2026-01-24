using UnityEngine;

public class PatrolExitDetectorHandler : MonoBehaviour
{
    [SerializeField] private Collider2D[] _waypoints;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private PigMovement _pigMovement;

    private Transform _targetPig;
    private int _firstWayPoint = 0;
    private int _lastWayPoint = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (Collider2D waypoint in _waypoints)
        {
            if (other == waypoint)
            {
                _flipper.Flip(!_flipper.IsFacingRight);

                _targetPig = waypoint == _waypoints[_firstWayPoint] ? _waypoints[_lastWayPoint].transform : _waypoints[_firstWayPoint].transform;
                _pigMovement.ChangeMovementType(_targetPig, false);
                break;
            }
        }
    }
}