using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health target))
        {
            target.ApplyDamage(_damage);
        }

        Destroy(gameObject);
    }

    public void Shoot(Vector3 startPoint, Vector3 speed)
    {
        _rigidbody.position = startPoint;
        _rigidbody.velocity = speed;
    }
}