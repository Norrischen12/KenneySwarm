using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barnacle : Enemies
{
    public Barnacle(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(3);
        this.setMovementSpeed(3);
        this.setHealth(10);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
