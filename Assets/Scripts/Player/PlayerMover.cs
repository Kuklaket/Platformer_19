using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private Flipper _flipper;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private GroundDetector _groundDetector;
    [SerializeField] private CharacterAnimator _characterAnimator;

    private bool _isMoving = false;

    public event Action<bool> MovementStateChanged;

    private void Awake()
    {
        _flipper = GetComponentInChildren<Flipper>();
        _groundDetector = GetComponent<GroundDetector>();
        _characterAnimator = GetComponent<CharacterAnimator>();
    }

    private void OnEnable()
    {
        _groundDetector.GroundedChanged += ChangeAnimation;
    }

    private void OnDisable()
    {
        _groundDetector.GroundedChanged -= ChangeAnimation;
    }

    private void OnDestroy()
    {
        _inputReader.Moving -= HandleMoveInput;
    }

    public void Initialize(InputReader inputReader)
    {
        _inputReader = inputReader;
        _inputReader.Moving += HandleMoveInput;
    }

    public bool IsRunning => _isMoving && _groundDetector.IsGrounded;

    public void HandleMoveInput(float horizontalInput)
    {
        Move(horizontalInput);
        CheckMovement(horizontalInput);
        _flipper.SetDirection(horizontalInput);
    }

    public void CheckMovement(float speed)
    {
        bool wasMoved = _isMoving;
        _isMoving = Mathf.Abs(speed) > 0;

        if (wasMoved != _isMoving)
            _characterAnimator.HandleMovementStateChange(IsRunning, _groundDetector.IsGrounded);
    }

    private void Move(float horizontalInput)
    {
        transform.Translate(new Vector3(horizontalInput * _moveSpeed * Time.deltaTime, 0, 0), Space.World);
    }

    private void ChangeAnimation(bool isGrounded)
    {
        _characterAnimator.HandleGroundedChange(isGrounded, IsRunning);
    }
}