using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemies
{
    public Bat(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(2);
        this.setMovementSpeed(7);
        this.setHealth(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
