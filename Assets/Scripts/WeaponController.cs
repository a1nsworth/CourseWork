using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private GameObject prefabSuperBullet;
    [SerializeField] private Transform firePoint;

    private event Action ShotBehavior;

    public void Shoot()
    {
        ShotBehavior?.Invoke();

        Instantiate(prefabBullet, firePoint.position, firePoint.rotation);
    }

    public void SupperShoot()
    {
        ShotBehavior?.Invoke();

        Instantiate(prefabSuperBullet, firePoint.position, firePoint.rotation);
    }
}