using System.Collections;
using UnityEngine;

public class Boomerang : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 direction;
    private float speed;
    private float bulletAtt;
    private GameObject currentWeapon;

    public bool canReturnBoomerang;
    public float flyTime;

    private void Start()
    {
        
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed, ForceMode2D.Impulse);
        currentWeapon.GetComponent<RangedWeapon2>().canShoot = false;
        StartCoroutine(flyTimeCounting());
    }
    private IEnumerator flyTimeCounting()
    {
        yield return new WaitForSeconds(flyTime);
        gameObject.layer = LayerMask.NameToLayer("Weapon");
        canReturnBoomerang = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.layer = LayerMask.NameToLayer("Weapon");
            canReturnBoomerang = true;
        }
        */
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 720f * 2) * Time.deltaTime);
        if (canReturnBoomerang)
        {
            returnBoomerang();
        }
    }
    private void returnBoomerang()
    {

        Vector2 returnDirection = (currentWeapon.transform.position - transform.position).normalized;
        //rb.AddForce(returnDirection * speed, ForceMode2D.Impulse);
        rb.velocity = returnDirection * speed;
        if (Vector3.Distance(transform.position, currentWeapon.transform.position) < 0.4f)
        {
            canReturnBoomerang = false;
            currentWeapon.GetComponent<RangedWeapon2>().canShoot = true;
            Destroy(gameObject);
        }
    }






    //Getters Setters
    public float getSpeed()
    {
        return this.speed;
    }

    public void setSpeed(float speed)
    {
        this.speed = speed;
    }

    public float getBulletAtt()
    {
        return this.bulletAtt;
    }

    public void setBulletAtt(float bulletAtt)
    {
        this.bulletAtt = bulletAtt;
    }
    public Vector3 getDirection()
    {
        return this.direction;
    }

    public void setDirection(Vector3 direction)
    {
        this.direction = direction;
    }
    public void setWeapon(GameObject weapon)
    {
        currentWeapon = weapon;
    }
}
