using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health _player;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        OnHealthChange();
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChange;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChange;
    }

    private void OnHealthChange()
    {
        _text.text = _player.CurrentHealth.ToString() + '/' + _player.MaxHealth;
    }
}
