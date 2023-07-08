using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Attributes
    private GameObject player;
    private float speed;
    private Vector3 direction;
    private int bulletAtt;
    private Rigidbody2D rb;
    private int bounceCount = 0;
    private Vector2 returnDirection;

    public bool normal;
    public bool bounce;
    public int maxBounce;
    public bool pierce;
    public bool statikkShiv;


    //Constructor

    //Methods
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction * speed;

        //Destroy(gameObject, 0.5f);
    }

    void Update()
    {
        if (bounce && bounceCount == 1)
        {
            bouncingAbility();
        }
    }

    //destroy bullet when hit obstacle or enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (normal)
        {
            normalAbility(collision);
        }
        else if (bounce)
        {
            bounceCount++;
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                Destroy(gameObject);
            }
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
    private void normalAbility(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    private void bouncingAbility()
    {
        returnDirection = (player.transform.position - transform.position).normalized;
        if (bounceCount >= maxBounce)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 reflectionDirection = returnDirection;
        rb.velocity = reflectionDirection * speed;
        
    }
    
}
