using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(GroundDetector))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 4f;

    private Rigidbody2D _rigidbody;
    private GroundDetector _groundDetector;
    private InputReader _inputReader;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetector = GetComponent<GroundDetector>();
    }

    public void Initialize(InputReader inputReader)
    {
        _inputReader = inputReader;
        _inputReader.JumpPressed += TryJump;
    }

    private void OnDestroy()
    {
        if (_inputReader != null)
            _inputReader.JumpPressed -= TryJump;
    }

    public void TryJump()
    {
        if (_groundDetector.IsGrounded)
            Jump();
    }

    private void Jump()
    {
        _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
    }
}