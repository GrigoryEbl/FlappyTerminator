using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] Transform _shootPoint;

    public void Shooting()
    {
        Instantiate(_prefab, _shootPoint.position, Quaternion.identity, transform);
    }
}
