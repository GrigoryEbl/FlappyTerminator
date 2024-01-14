using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    private PlayerMover _mover;
    private Health _health;
    private Shoot _shoot;

    private void Awake()
    {
        _mover = GetComponent<PlayerMover>();
        _health = GetComponent<Health>();
        _shoot = GetComponent<Shoot>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _shoot.Shooting(transform.right);
    }

    private void OnEnable()
    {
        _health.Died += OnDie;
    }

    private void OnDisable()
    {
        _health.Died -= OnDie;
    }

    public void ResetPlayer()
    {
        _mover.ResetBird();
    }

    public void OnDie()
    {
        ResetPlayer();
    }
}