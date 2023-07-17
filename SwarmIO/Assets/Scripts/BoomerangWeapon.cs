using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangWeapon : RangeWeapon
{
    public GameObject boomerangPrefab;
    public float attk;
    public float speed;
    public float fireRate;

    private void Start()
    {
        weaponAtt = attk;
        bulletSpeed = speed;
        weaponAttSpeed = fireRate;
    }

    public override void Fire(GameObject bulletPoint, GameObject aim)
    {
        GameObject boomerang = Instantiate(boomerangPrefab, bulletPoint.transform.position, Quaternion.identity);
        Vector3 direction = aim.transform.position - boomerang.transform.position;
        boomerang.GetComponent<Boomerang>().setDirection(direction);
        boomerang.GetComponent<Boomerang>().setBulletAtt(weaponAtt);
        boomerang.GetComponent<Boomerang>().setSpeed(bulletSpeed);
        boomerang.layer = LayerMask.NameToLayer("Boomerang");
    }

    public override IEnumerator shootCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(weaponAttSpeed);
        canShoot = true;
    }
}
