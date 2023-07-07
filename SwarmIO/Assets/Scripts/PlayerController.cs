using UnityEngine;

public class PlayerController : Entity
{
    public GameObject player;
    public GameObject rangeWeapon;
    public int speed;
    public GameObject bulletPrefab;
    public GameObject bulletPoint;
    public UIManager uiManager;
    public int HP;
    public bool IFrame;

    private Animator animator;
    public PlayerController(int health, int movementSpeed) : base(health, movementSpeed)
    {
        
    }
    private void Start()
    {
        animator = player.GetComponent<Animator>();
        movementSpeed = speed;
        setHealth(HP);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        RangeWeaponAim();
        updateHP();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
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
    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletPoint.transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().setBulletAtt(1);
        bullet.GetComponent<Bullet>().setSpeed(5f);
        bullet.GetComponent<Bullet>().setDirection(Camera.main.ScreenToWorldPoint(Input.mousePosition) - rangeWeapon.transform.position);
    }
    private void updateHP()
    {
        uiManager.setHP(getHealth());
    }
}
