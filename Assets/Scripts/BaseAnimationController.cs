using UnityEngine;

public abstract class BaseAnimationController : MonoBehaviour
{
    protected Animator Animator { get; private set; }

    protected virtual void Awake()
    {
        Animator = GetComponent<Animator>();
    }
}