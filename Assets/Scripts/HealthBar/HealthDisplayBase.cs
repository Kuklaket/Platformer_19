using UnityEngine;

public abstract class HealthDisplayBase : MonoBehaviour
{
    [SerializeField] protected HealthSystem _healthSystem;

    protected virtual void OnEnable()
    {
        _healthSystem.ValueChanged += UpdateHealthDisplay;
        UpdateHealthDisplay();
    }

    protected virtual void OnDisable()
    {
        _healthSystem.ValueChanged -= UpdateHealthDisplay;
    }

    protected abstract void UpdateHealthDisplay();
}

