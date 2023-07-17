using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject aim; 
    public float weaponAtt;
    public float bulletSpeed;
    public float weaponAttSpeed;
    public bool canShoot = true;
    public abstract void Fire(GameObject firePoint, GameObject aim);
    public abstract IEnumerator shootCD();
}
