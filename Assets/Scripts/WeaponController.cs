using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private Transform firePoint;

    private event Action ShotBehavior;
    
    public void Shoot()
    {
        ShotBehavior?.Invoke();
        
        Instantiate(prefabBullet, firePoint.position, firePoint.rotation);
    }
}