using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChaged;

    private void Start()
    {
        _mover = GetComponent<BirdMover>();
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

    public void Die()
    {
        GameOver?.Invoke();
    }
}
