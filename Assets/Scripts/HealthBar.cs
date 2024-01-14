using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _time = 1f;

    private void Start()
    {
        _slider.maxValue = _health.MaxHealth;
        _slider.value = _health.CurrentHealth;
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnChangeHealth;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnChangeHealth;
    }

    private void OnChangeHealth(int target)
    {
        StartCoroutine(ChangeHealth(target));
    }

    public IEnumerator ChangeHealth(int target)
    {
        while (_slider.value != target)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, target, _time * Time.deltaTime);

            yield return null;
        }
    }
}
