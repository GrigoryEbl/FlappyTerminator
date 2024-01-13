using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Transform _shootPoint;

    private void Start()
    {
        _shootPoint = GetComponentInParent<Transform>();
    }

    private void Update()
    {
       //transform.Translate(transform.parent.transform.right * _speed * Time.deltaTime, Space.World);
        _rigidbody.AddForce(_shootPoint.transform.right * _speed, ForceMode2D.Force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Health target))
        {
            target.ApplyDamage(_damage);
        }

        Destroy(gameObject);
    }
}