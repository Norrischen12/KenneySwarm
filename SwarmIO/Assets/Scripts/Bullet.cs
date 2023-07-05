using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //Attributes
    private float speed;
    private Vector3 direction;
    private int bulletAtt;
    
    //Constructor
    public Bullet (int bulletAtt)
    {
        
    }

    //Methods
    void Start()
    {
        this.tag = "Bullet";
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            direction = (hit.point - transform.position).normalized;
        }
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
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
}
