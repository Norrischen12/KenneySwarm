using Codice.Client.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperWeapon : RangeWeapon
{
    public override void Fire(GameObject firePoint, GameObject aim)
    {
        GameObject sniper = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
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
