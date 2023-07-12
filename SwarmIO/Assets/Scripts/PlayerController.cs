using System.Collections;
using UnityEngine;

public class PlayerController : Entity
{
    [Header("Reference")]
    public GameObject player;
    public GameObject rangeWeapon;
    public GameObject bulletPrefab;
    public GameObject bulletPoint;
    public GameObject aim;
    public GameObject gun;
    public GameObject boomerangPrefab;
    public UIManager uiManager;
    [Header("Status")]
    public float attkSpeed;
    public float moveSpeed;
    public int bulletAttk;
    public float bulletSpeed;
    public int boomerangAttk;
    public int HP;
    [Header("Abilities")]
    public bool IFrame;
    public bool Gun;
    public bool Boomerang;

    private Animator animator;
    public bool canShoot = true;
    public PlayerController(int health, int movementSpeed) : base(health, movementSpeed)
    {
        
    }
    private void Start()
    {
        animator = player.GetComponent<Animator>();
        movementSpeed = moveSpeed;
        setHealth(HP);
    }
    void Update()
    {
        PlayerMovement();
        RangeWeaponAim();
        UpdateHP();
        StartCoroutine(ActivateIframe());
        if (canShoot && Gun && Input.GetMouseButtonDown(0))
        {
            GunFire();
            StartCoroutine(ShootCD());
        }
        else if (canShoot && Boomerang && Input.GetMouseButtonDown(0))
        {
            BoomerangFire();
        }
    }
    private void PlayerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            Vector3 movement = new Vector3(moveHorizontal, moveVertical) * movementSpeed * Time.deltaTime;
            this.transform.position += movement;
            PlayerFlip(moveHorizontal);
            PlayerWalk();
        } else
        {
            PlayerIdle();
        }
    }
    private void PlayerFlip(float moveHorizontal)
    {
        if (moveHorizontal < 0)
        {
            player.transform.localScale = new Vector3(-1, 1, 1);
        } else if (moveHorizontal > 0)
        {
            player.transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void PlayerWalk()
    {
        animator.SetFloat("speed", 1);
    }
    private void PlayerIdle()
    {
        animator.SetFloat("speed", 0);
    }
    private void RangeWeaponAim()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 1f;
        Vector3 direction = mousePosition - rangeWeapon.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rangeWeapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void GunFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().setBulletAtt(bulletAttk);
        bullet.GetComponent<Bullet>().setSpeed(bulletSpeed);
        Vector3 direction = aim.transform.position - bulletPoint.transform.position;
        bullet.GetComponent<Bullet>().setDirection(direction);
    }
    private void BoomerangFire()
    {
        GameObject boomerang = Instantiate(boomerangPrefab, bulletPoint.transform.position, Quaternion.identity);
        Vector3 direction = aim.transform.position - boomerang.transform.position;
        boomerang.GetComponent<Boomerang>().setDirection(direction);
        boomerang.GetComponent<Boomerang>().setBulletAtt(boomerangAttk);
        boomerang.GetComponent<Boomerang>().setSpeed(bulletSpeed);
        boomerang.layer = LayerMask.NameToLayer("Boomerang");
    }
    private void UpdateHP()
    {
        uiManager.setHP(getHealth());
    }
    private IEnumerator ActivateIframe()
    {
        if (IFrame)
        {
            yield return new WaitForSeconds(0.5f);
            IFrame = false;
        }
    }
    private void ActivateGun()
    {
        Gun = true;
        gun.SetActive(Gun);
    }
    private void DeactivateGun()
    {
        Gun = false;
        gun.SetActive(Gun);
    }
    private void ActivateBoomerang()
    {
        Boomerang = true;
    }
    private void DeactivateBoomerang()
    {
        Boomerang = false;
    }
    private IEnumerator ShootCD()
    {
        canShoot = false;
        yield return new WaitForSeconds(attkSpeed);
        canShoot = true;
    }
}
