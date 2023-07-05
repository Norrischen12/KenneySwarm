using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : Entity
{
    public Ally(int health, int movementSpeed) : base(health, movementSpeed)
    {
        this.health = health;
        this.movementSpeed = movementSpeed;
    }

    

}
