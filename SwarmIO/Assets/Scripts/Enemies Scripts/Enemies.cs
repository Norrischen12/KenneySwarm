using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Entity
{
    //Attribute
    public Transform player;
    public int damage;
    private int originalHP;
    private GameObject HPPivot_obj;
    private float HPScaleX;



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
            HPScaleX = calculateHPPivot();

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
        if (collision.gameObject.CompareTag("Boomerang"))
        {
            Boomerang curr = collision.gameObject.GetComponent<Boomerang>();
            this.damaged(curr.getBulletAtt());
            HPScaleX = calculateHPPivot();
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
    public void setOriginalHP(int HP)
    {
        originalHP = HP;
        HPScaleX = calculateHPPivot();
    }
    private float calculateHPPivot()
    {
        return (float)this.getHealth() / originalHP;
    }
    public void setHPPivot(GameObject pivot)
    {
        HPPivot_obj = pivot;
    }
    public float getHPScaleX()
    {
        return HPScaleX;
    }

}
