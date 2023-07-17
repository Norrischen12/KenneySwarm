using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangWeapon : RangeWeapon
{
    public override void Fire(GameObject firePoint, GameObject aim)
    {
        GameObject boomerang = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
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
