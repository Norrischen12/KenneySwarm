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
    public GameObject sniperPrefab;
    public UIManager uiManager;
    [Header("Status")]
    public float bulletAttkSpeed;
    public float moveSpeed;
    public int bulletAttk;
    public float bulletSpeed;
    public int boomerangAttk;
    public float boomerangSpeed;
    public int sniperAttk;
    public float sniperAttkSpeed;
    public float sniperSpeed;
    public int HP;
    public int MN;
    [Header("Abilities")]
    public bool IFrame;
    public bool Gun;
    public bool Boomerang;
    public bool Sniper;
    public bool canShoot = true;

    private Animator animator;
    private Animator cameraAnimator;
    private bool canDash;
    
    public PlayerController(int health, int movementSpeed) : base(health, movementSpeed)
    {
        
    }
    private void Start()
    {
        animator = player.GetComponent<Animator>();
        cameraAnimator = Camera.main.GetComponent<Animator>();
        movementSpeed = moveSpeed;
        setHealth(HP);
    }
    void Update()
    {
        PlayerMovement();
        RangeWeaponAim();
        UpdateHP();
        StartCoroutine(ActivateIframe());
        CameraExtension();
        CheckCanDash();
        if (canShoot && Gun && Input.GetMouseButtonDown(0))
        {
            GunFire();
            StartCoroutine(ShootCD(bulletAttkSpeed));
        }
        else if (canShoot && Boomerang && Input.GetMouseButtonDown(0))
        {
            BoomerangFire();
        }
        else if (canShoot && Sniper && Input.GetMouseButtonDown(0))
        {
            SniperFire();
            StartCoroutine(ShootCD(sniperAttkSpeed));
        }
        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(PlayerDash());
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
        boomerang.GetComponent<Boomerang>().setSpeed(boomerangSpeed);
        boomerang.layer = LayerMask.NameToLayer("Boomerang");
    }
    private void SniperFire()
    {
        GameObject sniper = Instantiate(sniperPrefab, bulletPoint.transform.position, Quaternion.identity);
        Vector3 direction = aim.transform.position - sniper.transform.position;
        sniper.GetComponent<Sniper>().setDirection(direction);
        sniper.GetComponent<Sniper>().setBulletAtt(sniperAttk);
        sniper.GetComponent<Sniper>().setSpeed(sniperSpeed);
    }

    private void CameraExtension ()
    {
        if (Sniper)
        {
            cameraAnimator.SetBool("canExtendCamera", true);
        }
        else if (!Sniper)
        {
            cameraAnimator.SetBool("canExtendCamera", false);
        }
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
    private IEnumerator ShootCD(float time)
    {
        canShoot = false;
        yield return new WaitForSeconds(time);
        canShoot = true;
    }
    private IEnumerator PlayerDash()
    {
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(player.transform.localScale.x * 25f, 0f);
        yield return new WaitForSeconds(1f);
        rb.gravityScale = originalGravity;
    }
    private void CheckCanDash()
    {
        if (MN >= 5)
        {
            canDash = true;
        } 
        else
        {
            canDash = false;
        }
    }
}
