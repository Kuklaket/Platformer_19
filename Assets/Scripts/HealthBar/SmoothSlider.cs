using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothSlider : HealthDisplayBase
{
    [SerializeField] private UnityEngine.UI.Slider _slider;
    [SerializeField] private float _speed = 20f;

    private float _threshold = 0.01f;
    private float _currentValue;
    private Coroutine _coroutine;

    private void Awake()
    {
        _slider = GetComponent<UnityEngine.UI.Slider>();

        _slider.minValue = 0;
        _slider.maxValue = _healthSystem.MaxValue;
    }

    protected override void OnEnable()
    {
        base.OnEnable(); 
        _currentValue = _healthSystem.Value;
        _slider.value = _currentValue;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        if (_coroutine != null) StopCoroutine(_coroutine);
    }

    protected override void UpdateHealthDisplay()
    {
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(UpdateSmoothly());
    }

    private IEnumerator UpdateSmoothly()
    {
        float targetValue = _healthSystem.Value;

        while (Mathf.Abs(_currentValue - targetValue) > _threshold)
        {
            _currentValue = Mathf.MoveTowards(_currentValue, targetValue, _speed * Time.deltaTime);
            _slider.value = _currentValue;

            yield return null;
        }

        _slider.value = targetValue;
        _coroutine = null;
    }
}