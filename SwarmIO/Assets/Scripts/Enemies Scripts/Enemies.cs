using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : Entity
{
    //Attribute
    public Transform player;
    public float damage;
    private float originalHP;
    private GameObject HPPivot_obj;
    private float HPScaleX;



    //Constructor
    public Enemies(float health, float movementSpeed, float damage) : base(health, movementSpeed)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sniper"))
        {
            Bullet curr = collision.gameObject.GetComponent<Bullet>();
            this.damaged(curr.getBulletAtt());
            HPScaleX = calculateHPPivot();
        }
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
    public float getDamage()
    {
        return this.damage;
    }

    public void setDamage(float damage)
    {
        this.damage = damage;
    }
    public void setOriginalHP(float HP)
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
