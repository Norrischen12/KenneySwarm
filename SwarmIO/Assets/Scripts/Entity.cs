using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    //Attributes
    protected int health;
    protected int movementSpeed;


    //Constructor
    public Entity(int health, int movementSpeed)
    {
        this.health = health;
        this.movementSpeed = movementSpeed;
    }


    //Methods
    public virtual void damaged(int attPower)
    {
        this.health -= attPower;
        if (this.health <= 0){
            destroyObject();
        }
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }




    //Getters and Setters
    public int getHealth()
    {
        return this.health;
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public int getMovementSpeed()
    {
        return this.movementSpeed;
    }

    public void setMovementSpeed(int movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }
}
