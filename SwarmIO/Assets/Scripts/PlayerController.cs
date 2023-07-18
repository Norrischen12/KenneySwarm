using System.Collections;
using UnityEngine;

public class PlayerController : Entity
{
    [Header("Reference")]
    public GameObject player;
    public GameObject rangeWeapon;
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
    public bool hasGun;
    [Header("Abilities")]
    public bool IFrame;
    public bool canCameraExtension;
    

    private GameObject currentWeapon;
    private Animator animator;
    private Animator cameraAnimator;
    private bool canDash;
    
    
    public PlayerController(int health, int movementSpeed) : base(health, movementSpeed)
    {
        
    }
    private void Start()
    {
        //GetCurrentWeapon();
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
        CheckCanDash();
        if (hasGun && Input.GetMouseButtonDown(0))
        {
            RangedWeapon2 rw = currentWeapon.GetComponent<RangedWeapon2>();
            rw.Fire();
        }
    }
    public bool CheckCurrentWeapon()
    {
        if (rangeWeapon.transform.childCount == 0)
        {
            return false;
        }
        else
        {
            hasGun = true;
            return true;
        }
    }
    public GameObject GetCurrentWeapon()
    {
        currentWeapon = rangeWeapon.transform.GetChild(0).gameObject;
        Debug.Log("Current Weapon is: " + currentWeapon.name);
        if (currentWeapon.gameObject.name == "SniperWeapon")
        {
            canCameraExtension = true;
            CameraExtension();
        } else
        {
            canCameraExtension = false;
            CameraExtension();
        }
        return currentWeapon;
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
    private void CameraExtension()
    {
        if (canCameraExtension)
        {
            cameraAnimator.SetBool("canExtendCamera", true);
        }
        else if (!canCameraExtension)
        {
            cameraAnimator.SetBool("canExtendCamera", false);
        }
    }
}
