using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : RangeWeapon
{
    public override void Fire(GameObject bulletPoint, GameObject aim)
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().setBulletAtt(this.weaponAtt);
        bullet.GetComponent<Bullet>().setSpeed(bulletSpeed);
        Vector3 direction = aim.transform.position - bulletPoint.transform.position;
        bullet.GetComponent<Bullet>().setDirection(direction); 
    }

    public override IEnumerator shootCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(this.weaponAttSpeed);
        canShoot = true;
    }


}
