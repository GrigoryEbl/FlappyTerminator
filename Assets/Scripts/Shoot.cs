using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] Transform _shootPoint;
    [SerializeField] private float _velocity;

    public void Shooting( Vector3 direction)
    {
        ProjectileShoot(_shootPoint.position, direction * _velocity);
    }

    private void ProjectileShoot(Vector3 startPoint, Vector3 velocity)
    {
        var projectile = Instantiate(_prefab);

        projectile.Shoot(startPoint, velocity);
    }
}
