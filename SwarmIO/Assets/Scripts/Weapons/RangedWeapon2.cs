using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RangedWeapon2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject aim;
    public GameObject f;
    public float weaponAtt;
    public float bulletSpeed;
    public float weaponAttSpeed;
    public bool canShoot = true;

    private GameObject pistolFireAudio;
    private GameObject boomerangFireAuido;
    private GameObject sniperFireAuido;
    private UIManager uiManager;

    public enum BulletType
    {
        bullet,
        boomerang,
        sniper,
    }
    public BulletType bulletType;

    private PlayerController pc;
    private void Start()
    {
        pc = GameObject.Find("Player").GetComponent<PlayerController>();
        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        pistolFireAudio = GameObject.Find("Fire_audio");
        boomerangFireAuido = GameObject.Find("BoomerangAudio");
        sniperFireAuido = GameObject.Find("SniperAudio");
    }


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
            case BulletType.sniper:
                bulletType = BulletType.sniper;
                break;
        }
    }
    public void Fire()
    {
        if ((bulletType == BulletType.bullet || bulletType == BulletType.sniper) && canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().setBulletAtt(this.weaponAtt);
            bullet.GetComponent<Bullet>().setSpeed(bulletSpeed);
            Vector3 direction = aim.transform.position - firePoint.transform.position;
            bullet.GetComponent<Bullet>().setDirection(direction);
            StartCoroutine(shootCD());
            if (bulletType == BulletType.bullet)
            {
                GunFireAudio();
            }
            else if (bulletType == BulletType.sniper)
            {
                SniperAuido();
            }
            
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
            BoomerangAuido();
        }

    }
    public IEnumerator shootCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(weaponAttSpeed);
        canShoot = true;
    }

    //pick up weapon
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (this.gameObject.layer == LayerMask.NameToLayer("PickUp") && collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            bool hasWeapon = pc.CheckCurrentWeapon();
            if (hasWeapon)
            {
                //drop the current weapon and substitue
                GameObject curr = pc.GetCurrentWeapon();
                curr.transform.SetParent(null);
                Destroy(curr);
                pc.hasGun = false;
            } 

            //pick up weapon
            GameObject child = collision.transform.Find("RangeWeapon").gameObject;
            this.transform.SetParent(child.transform, false);
            this.transform.localPosition = new Vector3(1, 0, 0);
            aim.SetActive(true);
            f.SetActive(false);
            pc.hasGun = true;
            pc.GetCurrentWeapon();
            this.gameObject.layer = LayerMask.NameToLayer("Weapon");
            uiManager.updatName();
        }
    }
    private void GunFireAudio()
    {
        pistolFireAudio.GetComponent<AudioSource>().Play();
    }
    private void BoomerangAuido()
    {
        boomerangFireAuido.GetComponent<AudioSource>().Play();
    }
    private void SniperAuido()
    {
        sniperFireAuido.GetComponent<AudioSource>().Play();
    }
}
