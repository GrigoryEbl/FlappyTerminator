using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Spawner _spawner;
    private Health _health;
    private Shoot _shoot;
    private float _lastAttackTime;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _spawner = GetComponentInParent<Spawner>();
        _shoot = GetComponentInChildren<Shoot>();
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            _shoot.Shooting();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void OnEnable()
    {
        _health.Died += OnDie;
        _spawner.Activation += OnActivate;
    }

    private void OnDisable()
    {
        _health.Died -= OnDie;
        _spawner.Activation -= OnActivate;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Health player))
        {
            player.ApplyDamage(_damage);
            OnDie();
        }
    }

    private void OnDie()
    {
        gameObject.SetActive(false);
    }

    private void OnActivate()
    {
        _health.Heal(_health.MaxHealth);
    }
}