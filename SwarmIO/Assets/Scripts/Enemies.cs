using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Entity
{
    //Attribute
    public Transform player;



    //Constructor
   public Enemies(int health, int movementSpeed): base(health, movementSpeed)
    {
    }

    private void Start()
    {
        this.movementSpeed = 2;
    }

    //Methods
    private void Update()
    {
        this.tag = "Enemy";
        pursuit();
    }


    public void pursuit()
    {
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * this.movementSpeed * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet currBullet = collision.gameObject.GetComponent<Bullet>();
            this.damaged(currBullet.getBulletAtt());
        }
    }



}
