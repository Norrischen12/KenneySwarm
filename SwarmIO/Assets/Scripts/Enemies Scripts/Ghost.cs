using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemies
{
    public Ghost(int health, int movementSpeed, int damage) : base(health, movementSpeed, damage)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        this.setDamage(5);
        this.setMovementSpeed(3);
        this.setHealth(15);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
