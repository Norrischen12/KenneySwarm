using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Entity
{
    //Attribute
    public Transform player;
    public int damage;



    //Constructor
    public Enemies(int health, int movementSpeed, int damage) : base(health, movementSpeed)
    {
        this.damage = damage;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet currBullet = collision.gameObject.GetComponent<Bullet>();
            this.damaged(currBullet.getBulletAtt());
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player.IFrame == false)
            {
                player.damaged(this.getDamage());
                player.IFrame = true;
                
            }
            
        }
    }


    //Getters and Setters
    public int getDamage()
    {
        return this.damage;
    }

    public void setDamage(int damage)
    {
        this.damage = damage;
    }



}
