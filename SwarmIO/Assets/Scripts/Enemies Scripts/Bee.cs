using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : Enemies
{
    public Bee(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(1);
        this.setMovementSpeed(8);
        this.setHealth(4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
