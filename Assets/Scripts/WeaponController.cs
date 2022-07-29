using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform firePoint;

    public void Shoot()
    {
        Instantiate(prefabBullet,firePoint.position, firePoint.rotation);
    }
}
