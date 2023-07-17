using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangeWeapon : MonoBehaviour
{
    public float weaponAtt;
    public float bulletSpeed;
    public float weaponAttSpeed;
    public abstract void Fire(GameObject bulletPoint, GameObject aim);
    public abstract void canShoot(float time);
}
