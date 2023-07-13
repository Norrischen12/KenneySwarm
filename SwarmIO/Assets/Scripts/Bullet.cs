using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Attributes
    private float speed;
    private Vector3 direction;
    private int bulletAtt;
    private Rigidbody2D rb;

    public bool normal;
    public bool bounce;
    public int maxBounce;
    public bool pierce;
    public bool statikkShiv;
    


    //Constructor

    //Methods
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;
    }

    //destroy bullet when hit obstacle or enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
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

    public int getBulletAtt()
    {
        return this.bulletAtt;
    }

    public void setBulletAtt(int bulletAtt)
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

    
}
