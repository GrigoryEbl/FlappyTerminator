using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private int _score;
    private Health _health;
    private Shoot _shoot;

    public event UnityAction<int> ScoreChaged;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _health = GetComponent<Health>();
        _shoot = GetComponentInChildren<Shoot>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _shoot.Shooting();
    }

    private void OnEnable()
    {
        _health.Died += OnDie;
    }

    private void OnDisable()
    {
        _health.Died -= OnDie;
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChaged?.Invoke(_score);
    }

    public void ResetPlayer()
    {
        _score = 0;
        ScoreChaged?.Invoke(_score);
        _mover.ResetBird();
    }

    public void OnDie()
    {
        ResetPlayer();
    }
}