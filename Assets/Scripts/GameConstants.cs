using UnityEngine;

public class GameConstants
{
    public static class AnimatorParams
    {
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
        public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
        public static readonly int IsIdle = Animator.StringToHash(nameof(IsIdle));
        public static readonly int Attack = Animator.StringToHash(nameof(Attack));
        public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    }
}
