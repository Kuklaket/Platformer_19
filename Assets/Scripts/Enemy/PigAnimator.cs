using System.Collections;
using UnityEngine;

public class PigAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackResetDelay = 0.3f;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAttack()
    {
        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, true);
        StartCoroutine(ResetAttackAfterDelay());
    }

    private IEnumerator ResetAttackAfterDelay()
    {
        yield return new WaitForSeconds(_attackResetDelay);

        _animator.SetBool(GameConstants.AnimatorParams.IsAttack, false);
    }
}
