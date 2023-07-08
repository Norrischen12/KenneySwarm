using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemies
{
    public Slime(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(4);
        this.setMovementSpeed(5);
        this.setHealth(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
