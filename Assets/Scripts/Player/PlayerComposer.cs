using UnityEngine;

public class PlayerComposer : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Jumper _jumper;

    private void Awake()
    {
        _playerMover = GetComponent<PlayerMover>();
        _jumper = GetComponent<Jumper>();
    }

    private void Start()
    {
        ComposePlayer();
    }

    private void ComposePlayer()
    {
        _playerMover.Initialize(_inputReader);
        _jumper.Initialize(_inputReader);
    }
}