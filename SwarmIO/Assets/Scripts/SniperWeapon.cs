using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeapon : RangeWeapon
{
    public GameObject sniperPrefab;
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
        GameObject sniper = Instantiate(sniperPrefab, bulletPoint.transform.position, Quaternion.identity);
        Vector3 direction = aim.transform.position - sniper.transform.position;
        sniper.GetComponent<Sniper>().setDirection(direction);
        sniper.GetComponent<Sniper>().setBulletAtt(weaponAtt);
        sniper.GetComponent<Sniper>().setSpeed(weaponAttSpeed);
    }

    public override IEnumerator shootCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(weaponAttSpeed);
        canShoot = true;
    }
}
