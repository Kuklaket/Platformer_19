using UnityEngine;

public class Flipper : MonoBehaviour
{
    [SerializeField] private Transform _visualTransform;

    private bool _isFacingRight = true;
    private float _rightRotation = 0f;
    private float _leftRotation = 180f;
    private float _minDirectionThreshold = 0.1f;

    public bool IsFacingRight { get => _isFacingRight; set => _isFacingRight = value; }

    private void Awake()
    {
        _visualTransform = transform;
    }

    public void SetDirection(float xDirection)
    {
        bool shouldFaceRight = xDirection > 0;

        if (Mathf.Abs(xDirection) < _minDirectionThreshold) return;

        if (shouldFaceRight != IsFacingRight)
            Flip(shouldFaceRight);
    }

    public void Flip(bool isFaceRight)
    {
        if (IsFacingRight == isFaceRight) return;

        IsFacingRight = isFaceRight;
        float targetRotation = isFaceRight ? _rightRotation : _leftRotation;
        _visualTransform.localRotation = Quaternion.Euler(0f, targetRotation, 0f);
    }
}
