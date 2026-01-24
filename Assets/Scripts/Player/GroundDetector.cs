using System;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private float _groundCheckDistance = 1f;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private CharacterAnimator _characterAnimator;

    private Rigidbody2D _rigidbody;
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    public event Action<bool> GroundedChanged;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        CheckGrounded();
    }

    public void CheckGrounded()
    {
        bool wasGrounded = IsGrounded;

        Vector2 rayOrigin = _rigidbody.position;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, _groundCheckDistance, _groundMask);
        _isGrounded = hit.collider != null;

        if (wasGrounded != IsGrounded)
            GroundedChanged?.Invoke(_isGrounded);
    }
}