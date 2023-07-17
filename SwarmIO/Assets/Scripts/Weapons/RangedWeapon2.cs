using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject aim;
    public float weaponAtt;
    public float bulletSpeed;
    public float weaponAttSpeed;
    public bool canShoot = true;
    public enum BulletType
    {
        bullet,
        boomerang,
    }
    public BulletType bulletType;



    private void Update()
    {
        switch(bulletType)
        {
            case BulletType.bullet:
                bulletType = BulletType.bullet;
                break;
            case BulletType.boomerang:
                bulletType = BulletType.boomerang;
                break;
        }
    }
    public void Fire()
    {
        if (bulletType == BulletType.bullet && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().setBulletAtt(this.weaponAtt);
            bullet.GetComponent<Bullet>().setSpeed(bulletSpeed);
            Vector3 direction = aim.transform.position - firePoint.transform.position;
            bullet.GetComponent<Bullet>().setDirection(direction);
            StartCoroutine(shootCD());
        }
        else if (bulletType == BulletType.boomerang && canShoot)
        {
            GameObject boomerang = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            Vector3 direction = aim.transform.position - boomerang.transform.position;
            boomerang.GetComponent<Boomerang>().setWeapon(this.gameObject);
            boomerang.GetComponent<Boomerang>().setDirection(direction);
            boomerang.GetComponent<Boomerang>().setBulletAtt(this.weaponAtt);
            boomerang.GetComponent<Boomerang>().setSpeed(bulletSpeed);
            boomerang.layer = LayerMask.NameToLayer("Boomerang");
        }

    }
    public IEnumerator shootCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(weaponAttSpeed);
        canShoot = true;
    }
}
