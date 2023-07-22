using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Attributes
    public float health;
    public float movementSpeed;
    public int expValue;
    public GameObject Orb;


    //Constructor
    public Entity(float health, float movementSpeed)
    {
        this.health = health;
        this.movementSpeed = movementSpeed;
    }


    //Methods
    public virtual void damaged(float attPower)
    {
        this.health -= attPower;
        if (this.health <= 0){
            GameObject expOrb = Instantiate(Orb, transform.position, Quaternion.identity);
            expOrb.GetComponent<ExpOrb>().setExpValue(this.expValue);
            destroyObject();
        }
    }

    public void destroyObject()
    {
        if (this.gameObject.transform.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }




    //Getters and Setters
    public float getHealth()
    {
        return this.health;
    }

    public void setHealth(float health)
    {
        this.health = health;
    }

    public float getMovementSpeed()
    {
        return this.movementSpeed;
    }

    public void setMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }
}
