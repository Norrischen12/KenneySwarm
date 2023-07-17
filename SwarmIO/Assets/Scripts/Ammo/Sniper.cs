using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    private Vector3 direction;
    private float bulletAtt;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(direction * speed * 5);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
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
}
