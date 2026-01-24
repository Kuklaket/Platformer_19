using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int _value;
    [SerializeField] private int _maxValue = 100;

    public int Value { get => _value; private set => _value = Mathf.Clamp(value, 0, _maxValue); }

    public int MaxValue => _maxValue;

    public event Action Died;
    public event Action ValueChanged;

    public void GetDamage(int damageCount)
    {
        Value -= damageCount;

        ValueChanged?.Invoke();

        if (Value <= 0)
            Died?.Invoke();
    }

    public void AddHealth(int healthCount)
    {
        Value += healthCount;

        ValueChanged?.Invoke();
    }
}